namespace HMS.Models
{
    public class LeaveRequestModel
    {

        public string hostelAdmissionId { get; set; }
        public string leaveFromDate { get; set; }
        public string leaveToDate { get; set; }
        public string reason { get; set; }
        public string remarks { get; set; }
        public string hostelLeaveTypeId { get; set; }
        public string academicYear { get; set; }

        /*"":"1", 
"":"2018-12-10T13:45:00.000Z",
"":"2018-12-10T13:45:00.000Z",
"":"test", 
"":"test", 
"":"7", 
"":"2015" */
    }
}
