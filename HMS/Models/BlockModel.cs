using System.Collections.Generic;

namespace HMS.Models
{
    public class BlockModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string areaId { get; set; }
        public string hostelId { get; set; }
    }
    public class UpdateBlock
    {
        public string blockId { get; set; }
        public string userId { get; set; }
        public string blockName { get; set; }
        public string hostelId { get; set; }
        public string areaId { get; set; }
    }
    public class UpdateBlockResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateBlockErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<UpdateBlockError> errors { get; set; }
    }
    public class UpdateBlockError
    {
        public string message { get; set; }
    }
    public class BlockResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
}
