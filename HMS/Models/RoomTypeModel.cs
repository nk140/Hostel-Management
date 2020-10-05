using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HMS.Models
{
    public class RoomTypeModel:JsonProperty
    {
        public string id { get; set; }
        public string name { get; set; }
        public string hostelRoomTypeName { get; set; }
        public string noOfOccupants { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
    }
    public class RoomTypeResponses
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateRoomTypeModel
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string hostelRoomTypeName { get; set; }
        public string hostelId { get; set; }
    }
    public class UpdateRoomTypeResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateRoomErrorTypeResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<UpdateroomtypeError> errors { get; set; }
    }
    public class UpdateroomtypeError
    {
        public string message { get; set; }
    }
    public class SaveRoomType
    {
        public string userId { get; set; }
        public string hostelRoomTypeName { get; set; }
        public string noOfOccupants { get; set; }
    }
    public class RoomTypeResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class RoomErrorTypeResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Error> errors { get; set; }
    }
    public class Error
    {
        public string message { get; set; }
    }
}
