using System.Collections.Generic;

namespace HMS.Data
{
    public class Studentleavenotification
    {
        public IList<Studentlevanotificationmodel> studentlevanotifications { get; set; }
        public Studentleavenotification()
        {
            studentlevanotifications = new List<Studentlevanotificationmodel>();
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Parent Approved Leave of ravi",
                IsReadChecked = false
            });
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Casual Leave taken By Ravi",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Sick Leave taken by manish",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Parent Approved Leave of manish",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Parent Approved Leave of nisha",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Late leave taken by manish",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Emergency Leave taken By sarita",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Emergency Leave taken by saroj",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Emergency Leave taken by saroj",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Emergency Leave taken by saroj",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Emergency Leave taken by saroj",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Parent reject leave of saroj",
            //    IsReadChecked = false
            //});
            //studentlevanotifications.Add(new Studentlevanotificationmodel
            //{
            //    leavenotification = "Parent reject leave of sarita",
            //    IsReadChecked = false
            //});
        }
    }
    public class Studentlevanotificationmodel
    {
        public string leavenotification { get; set; }
        public bool IsReadChecked { get; set; }
    }
}
