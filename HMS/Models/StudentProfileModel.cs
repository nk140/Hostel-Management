using Newtonsoft.Json;

namespace HMS.Models
{
    public class StudentProfileModel
    {
        public string studentId { get; set; }
        public string wardenHostelId { get; set; }
        public string hostelAdmissionId { get; set; }
        public string wardenName { get; set; }
        public string userId { get; set; }
        public string wardenPhoneNo { get; set; }
        public string studentPhoneNo { get; set; }
        public string studentName { get; set; }
        public string studentemail { get; set; }
        public string hostelName { get; set; }
        public string floreNo { get; set; }
        public string bedNo { get; set; }
        public string roomName { get; set; }
        public string roomId { get; set; }
        public string applicationNo { get; set; }
        public string wardenDisciplinaryId { get; set; }
        public string disciplinaryName { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        [JsonIgnore]
        public bool Isbuttonvisible { get; set; }
    }
    public class StudentDisciplinaryDetails
    {
        public string studentId { get; set; }
        public string wardenHostelId { get; set; }
        public string wardenName { get; set; }
        public string wardenPhoneNo { get; set; }
        public string studentPhoneNo { get; set; }
        public string studentName { get; set; }
        public string studentemail { get; set; }
        public string hostelName { get; set; }
        public string floreNo { get; set; }
        public string bedNo { get; set; }
        public string roomName { get; set; }
        public string roomId { get; set; }
        public string applicationNo { get; set; }
        public string wardenDisciplinaryId { get; set; }
        public string disciplinaryName { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        [JsonIgnore]
        public bool Isbuttonvisible { get; set; }
    }
    public class WardenProfileModel
    {
        public string userId { get; set; }
        public string employeeId { get; set; }
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
        [JsonIgnore]
        public string serialno { get; set; }
    }
}
