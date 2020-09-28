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
    public class UpdateRoomBed
    {
        public string userId { get; set; }
        public string bedId { get; set; }
        public string bedNo { get; set; }
        public string hostelRoomId { get; set; }
        public string hostelId { get; set; }
    }
    public class UpdateRoomBedResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateRoomBedErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<RoomBedUpdateErrors> errors { get; set; }
    }
    public class RoomBedUpdateErrors
    {
        public string message { get; set; }
    }
    public class RoomBedData
    {
        public string bedId { get; set; }
        public string bedNo { get; set; }
        public string hostelRoomId { get; set; }
        public string hostelId { get; set; }
    }
    public class UpdateRoomModel
    {
        public string userId { get; set; }
        public string roomId { get; set; }
        public string roomName { get; set; }
        public string hostelId { get; set; }
        public string hostelRoomTypeId { get; set; }
        public string hostelBlockId { get; set; }
        public string floorId { get; set; }
        public string noOfBeds { get; set; }
    }
    public class UpdateRoomResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateRoomErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<RoomUpdateErrors> errors { get; set; }
    }
    public class RoomUpdateErrors
    {
        public string message { get; set; }
    }
    public class RoomDataModel
    {
        public string roomName { get; set; }
        public string hostelId { get; set; }
        public string hostelRoomTypeId { get; set; }
        public string hostelBlockId { get; set; }
        public string floorId { get; set; }
        public string noOfBeds { get; set; }
        public string userId { get; set; }
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
