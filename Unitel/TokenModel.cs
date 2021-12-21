using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Unitel
{
    public class TokenModel
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string TokenNumber { get; set; }
        public string TypeOfService { get; set; }
        public int TokenDigit { get; set; }
        public bool ActiveToken { get; set; }
    }

    public class ServiceRecord_Model
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string TokenNumber { get; set; }
        public string TypeOfService { get; set; }
        [BsonElement]
        public PersonRecord CustomerInfo { get; set; }
        [BsonElement]
        public SIM_Model UserSim { get; set; }

    }

    public class PersonRecord
    {
        [BsonElement]
        public string FathersName { get; set; }
        [BsonElement]
        public string MothersName { get; set; }
        [BsonElement]
        public string PhoneNumber { get; set; }
        [BsonElement]
        public string DateOfBirth { get; set; }
        [BsonElement]
        public string Nationality { get; set; }
        [BsonElement]
        public string NID_Number { get; set; }
        [BsonElement]
        public string DrivingLicenseNum { get; set; }
        [BsonElement]
        public string Gender { get; set; }
        [BsonElement]
        public string MaritalStatus { get; set; }
        [BsonElement]
        public AddressModel PresentAddress { get; set; }
        [BsonElement]
        public AddressModel PermanentAddress { get; set; }
    }

    public class CounterModel
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        public string ExecutiveName { get; set; }
        public string CounterNumber { get; set; }

    }
}
