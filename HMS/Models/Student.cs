using System.Collections.Generic;

namespace HMS.Models
{
    public class Students
    {
        public int admissionId { get; set; }
        public string courseId { get; set; }
        public string hostelId { get; set; }
        public string roomTypeId { get; set; }
        public string admissionDate { get; set; }
        public string applicationNo { get; set; }
        public string roomId { get; set; }
        public string bedId { get; set; }
        public string academicYear { get; set; }
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string parentName { get; set; }
        public string mobileNo { get; set; }
        public string email { get; set; }
    }
    public class VehicleRequestByStudent
    {
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string mobileNo { get; set; }
        public string sourcelocation { get; set; }
        public string destinationlocation { get; set; }
        public string requestedtype { get; set; }
    }
    public class FeedbackDetailsByStudent
    {
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string mobileNo { get; set; }
        public string serviceid { get; set; }
        public string servicerating { get; set; }
        public string description { get; set; }
    }
    public class Parents
    {
        public string Name { get; set; }
        public string Parentof { get; set; }
        public string contactno { get; set; }
    }
    public class UpdatePassword
    {
        public string userId { get; set; }
        public string password { get; set; }
    }
    public class UpdatePasswordResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdatePasswordErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<UpdatePasswordError> errors { get; set; }
    }
    public class UpdatePasswordError
    {
        public string message { get; set; }
    }
    public class StudentParentDetail
    {
        public string parentName { get; set; }
        public string parentPhoneNo { get; set; }
        public string studentName { get; set; }
        public string studentId { get; set; }
    }
    public class childleavehistory
    {

    }
    public class Studenterrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<studenterror> errors { get; set; }
    }
    public class studenterror
    {
        public string message { get; set; }
    }
}
