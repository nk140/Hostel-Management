using System.Collections.Generic;

namespace HMS.Models
{
    public class DisciplinaryType
    {
        public string name { get; set; }
        public string userId { get; set; }
    }
    public class DisciplinaryResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class DisciplinaryErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Disciplinary> errors { get; set; }
    }
    public class Disciplinary
    {
        public string message { get; set; }
    }
}
