using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Unitel
{
    class DatabaseFile
    {
        IMongoDatabase database;

        public DatabaseFile(string databaseName)
        {
            var client = new MongoClient("mongodb+srv://ekraHossain:ekraHossain17@unitel.m8yxy.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            database = client.GetDatabase(databaseName);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = database.GetCollection<T>(table);
            collection.InsertOne(record);
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

        public void UpsertRecord<T>(string table, string field, string data, T record)
        {
            var collection = database.GetCollection<T>(table);

            var result = collection.ReplaceOne(
                new BsonDocument(field, data),
                record,
                new ReplaceOptions { IsUpsert = true });


        }

        public void DeleteRecord<T>(string table, string field, string value)
        {
            var collection = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(field, value);
            collection.DeleteOne(filter);
        }

    }
}
