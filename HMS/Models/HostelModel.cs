using System.Collections.Generic;

namespace HMS.Models
{
    public class HostelModel
    {
        public string id { get; set; }
        public string hostelName { get; set; }
        public string areaId { get; set; }
        public string hostelForGender { get; set; }
        public string addressLine1 { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }

    }
    public class UpdateHostel
    {
        public string hostelId { get; set; }
        public string hostelName { get; set; }
        public string hostelForGender { get; set; }
        public string addressLine1 { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string areaId { get; set; }
    }
    public class UpdateHostelResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateHostelErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<HostelError> errors { get; set; }
    }
    public class HostelError
    {
        public string message { get; set; }
    }
    public class HostelResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
}
