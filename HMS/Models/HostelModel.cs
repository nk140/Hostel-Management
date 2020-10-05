using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HMS.Models
{
    public class HostelModel:JsonProperty
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
        [JsonIgnore]
        public string listcount { get; set; }
    }
    public class HostelAdmission
    {
        public string studentId { get; set; }
        public string courseId { get; set; }
        public string hostelId { get; set; }
        public string roomTypeId { get; set; }
        public string roomId { get; set; }
        public string bedId { get; set; }
        public string academicYear { get; set; }
        public string applicationNo { get; set; }
        public string firstName { get; set; }
        public string parentAddress { get; set; }
        public string parentPhoneNo { get; set; }

    }
    public class HostelAdmissionResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class HostelAdmissionErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<HostelAdmissionError> errors { get; set; }
    }
    public class HostelAdmissionError
    {
        public string message { get; set; }
    }
    public class HostelModelResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateHostel
    {
        public string userId { get; set; }
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
