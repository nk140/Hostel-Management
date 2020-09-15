using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Models
{
    public class ProfileUpdate
    {
        public string studentId { get; set; }
        public string stuPhoneNo { get; set; }
    }
    public class ProfileUpdateResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class ProfileUpdateErrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Updateerror> errors { get; set; }
    }
    public class Updateerror
    {
        public string message { get; set; }
    }
}
