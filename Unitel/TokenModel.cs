using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitel
{
    class TokenModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string TokenNumber { get; set; }
        public string TypeOfService { get; set; }
        public int TokenDigit { get; set; }
    }
}
