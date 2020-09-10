using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Models
{
    public class GuestRegistrationModel
    {
        public string guestName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phoneNo { get; set; }
        public string aadharNo { get; set; }
        public string userName { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
    }
    public class GuestRegResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class GuestRegErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<GuestError> errors { get; set; }
    }
    public class GuestError
    {
        public string message { get; set; }
    }
}
