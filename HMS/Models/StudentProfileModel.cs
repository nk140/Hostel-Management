using Newtonsoft.Json;

namespace HMS.Models
{
    public class StudentProfileModel
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
}
