using MongoDB.Bson.Serialization.Attributes;

namespace Unitel
{
    class PersonModel
    {
        [BsonId]
        public string ID { get; set; }
        [BsonElement]
        public string FirstName { get; set; }
        [BsonElement]
        public string LastName { get; set;  }
        [BsonElement]
        public string FathersName { get; set; }
        [BsonElement]
        public string MothersName { get; set; }
        [BsonElement]
        public string PhoneNumber { get; set; }
        [BsonElement]
        public string Nationality { get; set; }
        [BsonElement]
        public string NID_Number { get; set; }
        [BsonElement]
        public string DrivingLicenseNum { get; set; }
        [BsonElement]
        public AddressModel PresentAddress { get; set; }
        [BsonElement]
        public AddressModel PermanentAddress { get; set; }
        
    }

    public class AddressModel
    {
        [BsonElement]
        public string Street { get; set; }
        [BsonElement]
        public string State { get; set; }
        [BsonElement]
        public string PostCode { get; set; }
        [BsonElement]
        public string City { get; set; }
        [BsonElement]
        public string Country { get; set; }
    }

    public class EmployeeModel
    {
        [BsonId]
        public string ID { get; set; }
        [BsonElement]
        public string EmployeeID { get; set; }
        [BsonElement]
        public string Designation { get; set; }
        [BsonElement]
        public string Salary { get; set; }
        [BsonElement]
        public string FirstName { get; set; }
        [BsonElement]
        public string LastName { get; set; }
        [BsonElement]
        public string FathersName { get; set; }
        [BsonElement]
        public string MothersName { get; set; }
        [BsonElement]
        public string PhoneNumber { get; set; }
        [BsonElement]
        public string Nationality { get; set; }
        [BsonElement]
        public string NID_Number { get; set; }
        [BsonElement]
        public string DrivingLicenseNum { get; set; }
        [BsonElement]
        public AddressModel PresentAddress { get; set; }
        [BsonElement]
        public AddressModel PermanentAddress { get; set; }
    }

}
