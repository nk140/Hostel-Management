using System.Collections.Generic;

namespace HMS.Models
{
    public class RoomModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string areaId { get; set; }
        public string hostelId { get; set; }
        public string blockId { get; set; }
        public string floorId { get; set; }
        public string floorName { get; set; }
        public string bedno { get; set; }
        public string hostelRoomTypeId { get; set; }
    }
    public class RoomDataModel
    {
        public string roomName { get; set; }
        public string hostelId { get; set; }
        public string hostelRoomTypeId { get; set; }
        public string hostelBlockId { get; set; }
        public string floorId { get; set; }
        public string noOfBeds { get; set; }
    }
    public class RoomResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class RoomErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Errors> errors { get; set; }
    }
    public class Errors
    {
        public string message { get; set; }
    }
}
