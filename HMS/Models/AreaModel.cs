using System.Collections.Generic;

namespace HMS.Models
{
    public class AreaModel
    {
        public string id { get; set; }
        public string areaName { get; set; }
        public string stateId { get; set; }
    }
    public class SaveAreaModel
    {
        public string userId { get; set; }
        public string stateId { get; set; }
        public string areaName { get; set; }
    }
    public class AreaResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class AreaErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<AreaError> errors { get; set; }
    }
    public class AreaError
    {
        public string message { get; set; }
    }
}
