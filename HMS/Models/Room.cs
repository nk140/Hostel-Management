namespace HMS.Models
{
    public class Room
    {
        public string RoomImages { get; set; }
        public string RoomName { get; set; }
        public string Roomno { get; set; }
        public string GuestIcon { get; set; }
        public string day { get; set; }
        public string price { get; set; }
        public string Images { get; set; }
        public string No { get; set; }
    }
    public class RoomNameList
    {
        public string id { get; set; }
        public string name { get; set; }
        public string noOfBed { get; set; }
        public string hostelRoomTypeId { get; set; }
    }
    public class RoomNameResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
}
