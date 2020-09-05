using HMS.Models;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace HMS.Data
{
    public class GuestList
    {
        public IList<GuestModel> Guests { get; set; }
        public GuestList()
        {
            Guests = new List<GuestModel>();
            Guests.Add(new GuestModel
            {
                Name = "Mr. H.K. Srinivashan",
                Roomno = "2A-12",
                Contactno = "9234948909"
            });
            Guests.Add(new GuestModel
            {
                Name = "Mr. H.K.Tiwari",
                Roomno = "2A-22",
                Contactno = "7979003456"
            });
            Guests.Add(new GuestModel
            {
                Name = "Mr.Nitesh Dubey",
                Roomno = "1H-45",
                Contactno = "7989456787"
            });
            Guests.Add(new GuestModel
            {
                Name = "Mr.Manish Sharma",
                Roomno = "2A-45",
                Contactno = "9234948966"
            });
            Guests.Add(new GuestModel
            {
                Name = "Mr. H.K.Sharma",
                Roomno = "3S-12",
                Contactno = "9898765645"
            });
            Guests.Add(new GuestModel
            {
                Name = "Mr. S.K. Srinivashan",
                Roomno = "2A-32",
                Contactno = "9989435678"
            });
        }
    }
    public class RequestedGuestRoom
    {
        public IList<GuestRoombooking> guestbooking { get; set; }
        public RequestedGuestRoom()
        {
            guestbooking = new List<GuestRoombooking>();
            guestbooking.Add(new GuestRoombooking
            {
                Name = SecureStorage.GetAsync("firstName").GetAwaiter().GetResult(),
                Requestedroomno = "3t-56",
                Roomtype = "3 bed room",
                Status = "Booked"
            });
        }
    }
}
