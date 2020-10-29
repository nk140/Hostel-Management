using Newtonsoft.Json;

namespace HMS.Models
{
    public class StudentLeaveHistory
    {
        public string leaveFromDate { get; set; }
        public string leaveToDate { get; set; }
        public string reason { get; set; }
        public string hostelLeaveTypeId { get; set; }
        public object fromTime { get; set; }
        public object toTime { get; set; }
        public string leaveTypeId { get; set; }
        public string stuId { get; set; }
        public string stuName { get; set; }
        public string hostelName { get; set; }
        public string hostelBlock { get; set; }
        public string hostelType { get; set; }
        public string flooeNo { get; set; }
        public string hostelRoom { get; set; }
        public string bedNo { get; set; }
        public string mobileNo { get; set; }
        public string email { get; set; }
        public string isApproved { get; set; }
        public string leaveTypeName { get; set; }
        public string isParentApprove { get; set; }
        public string isParenetReject { get; set; }
        public string hostelAdmissionId { get; set; }
        [JsonIgnore]
        public string Parentleavestatus { get; set; }
    }
    public class wardenstatusonleavemodel
    {
        public string userId { get; set; }
        public string hostelAdmissionId { get; set; }
        public string isApproved { get; set; }
        public string leaveTypeId { get; set; }
        public string rejectReason { get; set; }
    }
    public class ViewLeaveStatusModel
    {
        public string hostelAdmissionId { get; set; }
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string leaveFromDate { get; set; }
        public string leaveToDate { get; set; }
        public string reason { get; set; }
        public string remarks { get; set; }
        public string leaveTypeId { get; set; }
        public string leaveTypeName { get; set; }
        public string parentApproved { get; set; }
        public string parentReject { get; set; }
        public string wardenApproved { get; set; }
        public string wardenReject { get; set; }
        public string rejectReason { get; set; }
        [JsonIgnore]
        public string leavestatus { get; set; }
        public bool isrejectreasonavaialble { get; set; }
    }
}
