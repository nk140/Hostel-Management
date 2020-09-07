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
    public class FloorData
    {
        public int id { get; set; }
        public int hostelId { get; set; }
        public string floorNo { get; set; }
        public int noOfRooms { get; set; }
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
