using HMS.Models;
using System.Collections.Generic;

namespace HMS.Data
{
    public class RoomDetailList
    {
        public IList<Room> Rooms { get; set; }
        public RoomDetailList()
        {
            Rooms = new List<Room>();
            Rooms.Add(new Room
            {
                RoomImages = "https://cdn.pixabay.com/photo/2014/08/11/21/40/wall-416062_960_720.jpg",
                RoomName = "Royal Luxury",
                Roomno = "1H-21",
                GuestIcon = "user.png",
                day = "1 day",
                price = "1000/-",
                Images = "filter.png",
                No = "1 bed"
            });
            Rooms.Add(new Room
            {
                RoomImages = "https://cdn.pixabay.com/photo/2014/08/11/21/40/wall-416062_960_720.jpg",
                RoomName = "Royal Luxury",
                Roomno = "1H-21",
                GuestIcon = "user.png",
                day = "1 day",
                price = "1000/-",
                Images = "filter.png",
                No = "1 bed"
            });
            Rooms.Add(new Room
            {
                RoomImages = "https://cdn.pixabay.com/photo/2014/08/11/21/40/wall-416062_960_720.jpg",
                RoomName = "Royal Luxury",
                Roomno = "1H-21",
                GuestIcon = "user.png",
                day = "1 day",
                price = "1000/-",
                Images = "filter.png",
                No = "1 bed"
            });
            Rooms.Add(new Room
            {
                RoomImages = "https://cdn.pixabay.com/photo/2014/08/11/21/40/wall-416062_960_720.jpg",
                RoomName = "Royal Luxury",
                Roomno = "1H-21",
                GuestIcon = "user.png",
                day = "1 day",
                price = "1000/-",
                Images = "filter.png",
                No = "1 bed"
            });
        }
    }
}
