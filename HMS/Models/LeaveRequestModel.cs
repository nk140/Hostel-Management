using System.Collections.Generic;

namespace HMS.Models
{
    public class LeaveRequestModel
    {
        public string leaveFromDate { get; set; }
        public string leaveToDate { get; set; }
        public string reason { get; set; }
        public string remarks { get; set; }
        public string hostelLeaveTypeId { get; set; }
        public string academicYear { get; set; }
    }
    public class LeaveResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class LeaveErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<LeaveError> errors { get; set; }
    }
    public class LeaveError
    {
        public string message { get; set; }
    }
}
