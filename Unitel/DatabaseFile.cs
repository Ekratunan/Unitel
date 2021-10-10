using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitel
{
    class DatabaseFile
    {

        public void DatabaseCon(string databaseName, string collectionName)
        {
            

        }

        public bool PasswordVerify(string userName, string password)
        {
            bool verification = false;

            var settings = MongoClientSettings.FromConnectionString("mongodb://ekraHossain:ekraHossain17@unitel-shard-00-00.m8yxy.mongodb.net:27017,unitel-shard-00-01.m8yxy.mongodb.net:27017,unitel-shard-00-02.m8yxy.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-110s91-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("employee_info");
            var collection = database.GetCollection<BsonDocument>("passwords");

            var filter = Builders<BsonDocument>.Filter.Eq("userName", userName);

            BsonDocument studentDocument = collection.Find(filter).FirstOrDefault();
            string pass = studentDocument.ToString();

            if(pass == password)
            {
                verification = true;
            }

            return verification;
        }

       

     
    }
}
