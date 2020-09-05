namespace HMS.Models
{
    public class BlockModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string areaId { get; set; }
        public string hostelId { get; set; }
    }
    public class BlockResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
}
