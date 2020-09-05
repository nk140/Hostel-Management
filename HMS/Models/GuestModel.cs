namespace HMS.Models
{
    public class GuestModel
    {
        public string Name { get; set; }
        public string Roomno { get; set; }
        public string Contactno { get; set; }
    }
    public class GuestRoombooking
    {
        public string Name { get; set; }
        public string Requestedroomno { get; set; }
        public string Roomtype { get; set; }
        public string Status { get; set; }
    }
}
