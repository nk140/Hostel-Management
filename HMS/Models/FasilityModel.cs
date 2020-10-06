using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HMS.Models
{
    public class FasilityModel
    {
        public string userId { get; set; }
        public string name { get; set; }
    }
    public class ViewFacility:JsonProperty
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
    }
    public class UpdateFacility
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
    }
    public class UpdateFacilityresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateFacilityerrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<UpdateErrorFacility> errors { get; set; }
    }
    public class UpdateErrorFacility
    {
        public string message { get; set; }
    }
    public class Facilityresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
}
