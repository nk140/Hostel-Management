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
        public string userId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string disciplinaryTypeId { get; set; }
        public string description { get; set; }
        public string hostelAdmissionId { get; set; }
        //[JsonIgnore]
        //public string Studentname { get; set; }
    }
    public class UpdateDisciplinaryActionbywarden
    {
        public string userId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string disciplinaryTypeId { get; set; }
        public string description { get; set; }
        public string hostelAdmissionId { get; set; }
        public string wardenDisciplinaryId { get; set; }
    }
    public class ViewDisciplinaryActionbywarden
    {
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string hostelAdmissionId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string appicationNo { get; set; }
        public string disciplinaryTypeId { get; set; }
        public string wardenDisciplinaryId { get; set; }
        public string disciplinaryTypeName { get; set; }
        public string discription { get; set; }
        [JsonIgnore]
        public bool Isbuttonvisible { get; set; }
    }
    public class ViewDisciplinaryType
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
        public bool Isbuttonvisible { get; set; }
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
