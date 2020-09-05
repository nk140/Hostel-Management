namespace HMS.Models
{
    public class ParentStudentLeaveStatus
    {
        public int hostelLeaveId { get; set; }
        public string reason { get; set; }
        public string remark { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string leaveType { get; set; }
        public string isParentApproved { get; set; }
    }
}
