using System.Collections.Generic;

namespace HMS.Models
{
    public class RegistrationModel
    {
        public string studentName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phoneNo { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string adharNo { get; set; }
    }
    public class ParentRegistration
    {
        public string parentName { get; set; } //
        public string address { get; set; } //
        public string email { get; set; } //
        public string phoneNo { get; set; } //
        public string aadharNo { get; set; } //
        public string userName { get; set; } //
        public string password { get; set; } //
    }
    public class ParentRegistrationResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class ParentRegistrationErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<ParentRegistrationError> errors { get; set; }
    }
    public class ParentRegistrationError
    {
        public string message { get; set; }
    }
    public class RegistrationResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class RegistrationErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<RegistrationError> errors { get; set; }
    }
    public class RegistrationError
    {
        public string message { get; set; }
    }
}
