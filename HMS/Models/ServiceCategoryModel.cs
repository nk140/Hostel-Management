using System.Collections.Generic;

namespace HMS.Models
{
    public class ServiceCategoryModel
    {
        public string userId { get; set; }
        public string name { get; set; }
    }
    public class ServicecategoryResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class ServiceCategoryErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Errorpage> errors { get; set; }
    }
    public class Errorpage
    {
        public string message { get; set; }
    }
}
