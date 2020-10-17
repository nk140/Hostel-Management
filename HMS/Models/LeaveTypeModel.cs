﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HMS.Models
{
    public class LeaveTypeModel
    {
        public string leaveTypeId { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
        [JsonIgnore]
        public string listcount { get; set; }
        public bool Isbuttonvisible { get; set; }
    }
    public class CreateLeaveTypeModel
    {
        public string userId { get; set; }
        public string name { get; set; }
    }
    public class LeaveStatusModel
    {
        public string hostelAdmissionId { get; set; }
        public string leaveTypeId { get; set; }
        public string isApproved { get; set; }
    }
    public class UpdateLeavetype
    {
        public string userId { get; set; }
        public string leaveTypeId { get; set; }
        public string name { get; set; }
    }
    public class LeaveTypeerrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<Leavetypeerror> errors { get; set; }
    }
    public class Leavetypeerror
    {
        public string message { get; set; }
    }
}
