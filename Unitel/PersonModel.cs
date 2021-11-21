using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Unitel
{
    class PersonModel
    {
        [BsonId]
        public Guid ID { get; set; }
        [BsonElement]
        public string MobileNumber { get; set; }
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

    public class SIM_Model
    {
        [BsonId]
        public Guid ID { get; set; }
        [BsonElement]
        public string MobileNumber { get; set; }
        [BsonElement]
        public string PackageType { get; set; }
        [BsonElement]
        public string NetworkVersion { get; set; }
        [BsonElement]
        public string UserLevel { get; set; }
        [BsonElement]
        public string SIM_Version { get; set; }
        [BsonElement]
        public string DateOfIssue { get; set; }
        [BsonElement]
        public string SerialNumber { get; set; }
        [BsonElement]
        public string Device_IMEI { get; set; }
        [BsonElement]
        public string Device_Model { get; set; }
        [BsonElement]
        public SIM_Pack simPackage { get; set; }

    }

    public class SIM_Pack
    {
        [BsonElement]
        public string Balance { get; set; }
        [BsonElement]
        public string balanceValidity { get; set; }
        [BsonElement]
        public string DataPack { get; set; }
        [BsonElement]
        public string dataValidity { get; set; }
        [BsonElement]
        public string SMS_Pack { get; set; }
        [BsonElement]
        public string smsValidity { get; set; }
        [BsonElement]
        public string Talk_Time { get; set; }
        [BsonElement]
        public string talkTimeValidity { get; set; }
    }

    public class PassBook
    {
        [BsonId]
        public Guid ID { get; set; }
        [BsonElement]
        public string EmployeeID { get; set; }
        [BsonElement]
        public string Password { get; set; }
        [BsonElement]
        public string AdminStatus { get; set; }
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
        public Guid ID { get; set; }
        [BsonElement]
        public string AdminStatus { get; set; }
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

}
