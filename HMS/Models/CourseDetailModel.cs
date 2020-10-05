using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Models
{
    public class CourseDetailModel
    {
        public string userId { get; set; }
        public string courseId { get; set; }
        public string courseName { get; set; }
        public string code { get; set; }
    }
    public class CourseModel
    {
        public string userId { get; set; }
        public string courseName { get; set; }
        public string code { get; set; }
    }
    public class CourseResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class CourseErrorResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<CourseError> errors { get; set; }
    }
    public class CourseError
    {
        public string message { get; set; }
    }
}
