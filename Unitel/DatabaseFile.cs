using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitel
{
    class DatabaseFile
    { 
        public void LogInDataInsert(string exeName, string counter)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://ekraHossain:ekraHossain17@unitel-shard-00-00.m8yxy.mongodb.net:27017,unitel-shard-00-01.m8yxy.mongodb.net:27017,unitel-shard-00-02.m8yxy.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-110s91-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("employee_info");
            var collection = database.GetCollection<BsonDocument>("active_employee");

            var document = new BsonDocument {
                { "exeName", exeName },
                { "counter", counter }
                };

            collection.InsertOne(document);
        }

     
    }
}
