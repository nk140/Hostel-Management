using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HMS.Models
{
    public class WardenServiceModel
    {
        public int id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
        public bool Isbuttonvisible { get; set; }
    }
}
