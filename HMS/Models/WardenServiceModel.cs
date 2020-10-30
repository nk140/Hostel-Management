using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HMS.Models
{
    public class WardenServiceModel
    {
        public int id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
        public bool Isbuttonvisible { get; set; }
    }
    public class ViewRequestedServiceModel
    {
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string areaId { get; set; }
        public string areaName { get; set; }
        public string hostelId { get; set; }
        public string hostelName { get; set; }
        public string roomId { get; set; }
        public string roomName { get; set; }
        public string description { get; set; }
        public string serviceTypeId { get; set; }
        public string serviceTypeName { get; set; }
        [JsonIgnore]
        public bool Isbuttonvisible { get; set; }
    }
    public class ServiceStatusModel
    {

    }
    public class AssignServiceModel
    {
        public string requestPersonName { get; set; }
        public string requestPersonJobTitle { get; set; }
        public string requestPersonPhoneNo { get; set; }
    }
    public class ViewRequestedServiceStatusModel
    {
        public string personName { get; set; }
        public string personJob { get; set; }
        public string serviceTypeId { get; set; }
        public string personMobileNo { get; set; }
        public string studentId { get; set; }
        public string personRating { get; set; }
        public bool workStatus { get; set; }
        [JsonIgnore]
        public bool isbuttonvisible { get; set; }
        public string WorkStatus { get; set; }
    }
    public class RequestServiceModel
    {
        public string roomId { get; set; }
        public string roomServiceTypeId { get; set; }
        public string description { get; set; }
    }
}
