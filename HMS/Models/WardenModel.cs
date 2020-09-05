using System.Collections.Generic;

namespace HMS.Models
{
    public class WardenModel
    {

        public string roleId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string isWarden { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string dateOfJoining { get; set; }
        public string permanent_address_line_1 { get; set; }
        public string permanent_address_line_2 { get; set; }
        public string permanent_address_city { get; set; }
        public string email { get; set; }
        public string mobile_no { get; set; }
        public string gender { get; set; }


    }
    public class WardenResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class Wardenerrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Wardenerror> errors { get; set; }
    }
    public class Wardenerror
    {
        public string message { get; set; }
    }
}
