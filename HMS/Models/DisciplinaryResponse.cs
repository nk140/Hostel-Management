using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HMS.Models
{
    public class DisciplinaryType
    {
        public string name { get; set; }
        public string userId { get; set; }
    }
    public class DisciplinaryActionbywarden
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string StudRegno { get; set; }
        public string Studentname { get; set; }
        public string DisciplinaryType { get; set; }
        public string Description { get; set; }
    }
    public class ViewDisciplinaryType:JsonProperty
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
    }
    public class UpdateDisciplinaryType
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
    }
    public class UpdateDisciplinaryResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateDisciplinaryErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<UpdateDisciplinary> errors { get; set; }
    }
    public class UpdateDisciplinary
    {
        public string message { get; set; }
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
