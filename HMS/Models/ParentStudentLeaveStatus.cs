using Newtonsoft.Json;

namespace HMS.Models
{
    public class ParentStudentLeaveStatus
    {
        public int hostelLeaveId { get; set; }
        public string leaveTypeId { get; set; }
        public string reason { get; set; }
        public string remark { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string leaveTypeName { get; set; }
        public string isParentApproved { get; set; }
        [JsonIgnore]
        public string ParentStatus { get; set; }
    }
    public class ChildHostelDetailModel
    {
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
}
