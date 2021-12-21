using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Unitel
{
    internal class DatabaseFile
    {
        IMongoDatabase database;

        string databaseNameGlobal;

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reserved);

        int waitingCountDown = 0;

        public DatabaseFile(string databaseName)
        {
            databaseNameGlobal = databaseName;
        ConnectDatabase:
            try
            {
                var client = new MongoClient("mongodb+srv://ekraHossain:ekraHossain17@unitel.m8yxy.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
                database = client.GetDatabase(databaseName);
            }
            catch (Exception)
            {
                while (!InternetGetConnectedState(out _, 0))
                {
                    waitingCountDown++;
                }


                Console.WriteLine(waitingCountDown);
                goto ConnectDatabase;

            }
        }

        public void InsertRecord<T>(string table, T record)
        {
            try
            {
                var collection = database.GetCollection<T>(table);
                collection.InsertOne(record);
            }
            catch (NullReferenceException)
            {
            tryConAgain:
                if (InternetGetConnectedState(out _, 0))
                {
                    var client = new MongoClient("mongodb+srv://ekraHossain:ekraHossain17@unitel.m8yxy.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
                    database = client.GetDatabase(databaseNameGlobal);
                }
                else
                {
                    goto tryConAgain;
                }
                Console.WriteLine("Insertion Error");

            }


        }

        public List<T> LoadRecords<T>(string table)
        {
            try
            {
                var collection = database.GetCollection<T>(table);
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public T LoadRecordbyIdentity<T>(string table, string field, string value)
        {
        tryCon:
            try
            {
                var collection = database.GetCollection<T>(table);
                var filter = Builders<T>.Filter.Eq(field, value);

                return collection.Find(filter).FirstOrDefault();
            }
            catch (Exception)
            {
                waitingCountDown = 0;

                while (!InternetGetConnectedState(out _, 0))
                {
                    waitingCountDown++;
                }

                goto tryCon;
            }
        }


        public void UpsertRecord<T>(string table, BsonObjectId Id, T record)
        {
        tryCon:
            try
            {
                var collection = database.GetCollection<T>(table);
                collection.ReplaceOne(
                new BsonDocument("_id", Id),
                record,
                new ReplaceOptions { IsUpsert = true });
            }
            catch (Exception)
            {
                Console.WriteLine("Writing Error");
                waitingCountDown = 0;

                while (!InternetGetConnectedState(out _, 0))
                {
                    waitingCountDown++;
                }

                goto tryCon;
            }
        }

        public void DeleteRecord<T>(string table, BsonObjectId Id)
        {
        tryCon:
            try
            {
                var collection = database.GetCollection<T>(table);

                var filter = Builders<T>.Filter.Eq("_id", Id);
                collection.DeleteOne(filter);
            }
            catch (Exception)
            {
                waitingCountDown = 0;
                while (!InternetGetConnectedState(out _, 0))
                {
                    waitingCountDown++;
                }

                goto tryCon;
            }
        }
    }
}
