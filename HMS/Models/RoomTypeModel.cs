using System.Collections.Generic;

namespace HMS.Models
{
    public class RoomTypeModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string hostelRoomTypeName { get; set; }
        public string noOfOccupants { get; set; }
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
