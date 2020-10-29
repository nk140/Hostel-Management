using Newtonsoft.Json;

namespace HMS.Models
{
    public class UserModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string firstName { get; set; }
        public string dateOfBirth { get; set; }
        public string dateOfJoining { get; set; }
        public string permanent_address_line_1 { get; set; }
        public string permanent_address_line_2 { get; set; }
        public string permanent_address_city { get; set; }
        public string email { get; set; }
        public string mobile_no { get; set; }
        public string blood_group { get; set; }
        public string gender { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public string applicationNo { get; set; }
        public string studentName { get; set; }
        public string studentId { get; set; }
        public string wardenDisciplinaryId { get; set; }
        public string disciplinaryName { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string hostelAdmisiionId { get; set; }
        public string hostelId { get; set; }
        public string hostelName { get; set; }
        public string roomId { get; set; }
        public string roomName { get; set; }
        public string roomBedId { get; set; }
        public string roomBedName { get; set; }
        public string blockId { get; set; }
        public string blockName { get; set; }
        [JsonIgnore]
        public bool Isbuttonvisible { get; set; }
    }
    public class StudentModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string firstName { get; set; }
        public string dateOfBirth { get; set; }
        public string dateOfJoining { get; set; }
        public string permanent_address_line_1 { get; set; }
        public string permanent_address_line_2 { get; set; }
        public string permanent_address_city { get; set; }
        public string email { get; set; }
        public string mobileNo { get; set; }
        public string blood_group { get; set; }
        public string gender { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public string applicationNo { get; set; }
        public string studentName { get; set; }
        public string wardenDisciplinaryId { get; set; }
        public string disciplinaryName { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        [JsonIgnore]
        public bool Isbuttonvisible { get; set; }
    }
    public class WardenModels
    {
        public int userId { get; set; }
        public int employeeId { get; set; }
        public string wardenName { get; set; }
        public string dateOfBirth { get; set; }
        public string dateOfJoining { get; set; }
        public string permanent_address_line_1 { get; set; }
        public string permanent_address_line_2 { get; set; }
        public string permanent_address_city { get; set; }
        public string wardenEmail { get; set; }
        public string wardenPhoneNo { get; set; }
        public string blood_group { get; set; }
        public string wardenGender { get; set; }
        public string isWarden { get; set; }
        public string areaId { get; set; }
        public string areaName { get; set; }
        public string hostelId { get; set; }
        public string hostelName { get; set; }
        public string userType { get; set; }
    }
}
