using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Unitel
{
    internal class DatabaseFile
    {
        readonly IMongoDatabase database;

        public DatabaseFile(string databaseName)
        {
            try
            {
                var client = new MongoClient("mongodb+srv://ekraHossain:ekraHossain17@unitel.m8yxy.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
                database = client.GetDatabase(databaseName);
            }
            catch(Exception)
            {
                Console.WriteLine("Connection Failed");
            }

            
            
        }

        public void InsertRecord<T>(string table, T record)
        {
            try
            {
                var collection = database.GetCollection<T>(table);
                collection.InsertOne(record);
            }
            catch (MongoConnectionException)
            {
                Console.WriteLine("Insertion Error");
            }
            
            
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = database.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordbyIdentity<T>(string table, string field, string value)
        {
            var collection = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(field, value);

            return collection.Find(filter).FirstOrDefault();
        }

    
        public void UpsertRecord<T>(string table, Guid Id , T record)
        {
            var collection = database.GetCollection<T>(table);

            try
            {
                collection.ReplaceOne(
                new BsonDocument("_id", Id),
                record,
                new ReplaceOptions { IsUpsert = true });
            }
            catch(MongoConnectionException)
            {
                Console.WriteLine("Writing Error");
            }
        }

        public void DeleteRecord<T>(string table, Guid Id)
        {
            var collection = database.GetCollection<T>(table);
            
            var filter = Builders<T>.Filter.Eq("_id", Id);
            collection.DeleteOne(filter);
        }

    }
}
