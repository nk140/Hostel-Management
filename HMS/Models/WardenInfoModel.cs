using System.Collections.Generic;

namespace HMS.Models
{
    public class WardenInfoModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contact { get; set; }
        public string userId { get; set; }
    }
    public class UpdateWarden
    {
        public string userId { get; set; }
        public string wardenId { get; set; }
        public string name { get; set; }
        public string contactNo { get; set; }

    }
    public class UpdateWardenResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateWardenErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Updatewardenerror> errors { get; set; }
    }
    public class Updatewardenerror
    {
        public string message { get; set; }
    }
}
