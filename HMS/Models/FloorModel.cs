using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HMS.Models
{
    public class FloorModel
    {
        public string floorName { get; set; }
        public string hostelId { get; set; }
        public string blocks_id { get; set; }
        //public string hostelRoomTypeId { get; set; }
        public string noOfRooms { get; set; }


        /*
        "":"Floor4", 
"hostelId":"1", 
"":"1", 
"noOfRooms":"1", 
"areaId":"1", 
"blocks_id":"1"
         */
    }
    public class FloorData:JsonProperty
    {
        public int id { get; set; }
        public int hostelId { get; set; }
        public string floorNo { get; set; }
        public int noOfRooms { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
    }
    public class FloorDataResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateFloorData
    {
        public string floorId { get; set; }
        public string userId { get; set; }
        public string floorName { get; set; }
        public string hostelId { get; set; }
        public string noOfRooms { get; set; }
        public string blocks_id { get; set; }
    }
    public class UpdateFloorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateFloorErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Updatefloorerror> errors { get; set; }
    }
    public class Updatefloorerror
    {
        public string message { get; set; }
    }
    public class FloorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class FloorErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<floorerror> errors { get; set; }
    }
    public class floorerror
    {
        public string message { get; set; }
    }
}
