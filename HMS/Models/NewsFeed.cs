using System.Collections.Generic;

namespace HMS.Models
{
    public class NewsFeed
    {
        public int id { get; set; }
        public string newsTitle { get; set; }
        public string newsDescription { get; set; }
        public string startDate { get; set; }
        public string lastDate { get; set; }
        public string linkId { get; set; }
        public string linkUrl { get; set; }
    }
    public class UpdateNewsFeed
    {
        public int id { get; set; }
        public string newsTitle { get; set; }
        public string newsDescription { get; set; }
        public string startDate { get; set; }
        public string lastDate { get; set; }
        public string linkId { get; set; }
        public string displayfor { get; set; }
    }
    public class UpdateNewsFeedResponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class UpdateNewsFeederrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<UpdateNewsFeederror> errors { get; set; }
    }
    public class UpdateNewsFeederror
    {
        public string message { get; set; }
    }
    public class NewsFeederrorresponse
    {
        public string status { get; set; }
        public string code { get; set; }
        public List<NewsFeederror> errors { get; set; }
    }
    public class NewsFeederror
    {
        public string message { get; set; }
    }
}
