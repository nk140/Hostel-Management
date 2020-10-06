using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HMS.Models
{
    public class LeaveTypeModel:JsonProperty
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
    }
    public class LeaveTypeerrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Leavetypeerror> errors { get; set; }
    }
    public class Leavetypeerror
    {
        public string message { get; set; }
    }
}
