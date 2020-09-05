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
                leavenotification = "Parent Approved Leave for Hostelleave id 7",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Casual Leave taken By Student(Leave Id 66)",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Emergency Leave taken By Student(Leave Id 6)",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Parent Approved Leave for Hostelleave id 6",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Parent Approved Leave for Hostelleave id 6",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Emergency Leave taken By Student(Leave Id 6)",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Emergency Leave taken By Student(Leave Id 6)",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Emergency Leave taken By Student(Leave Id 6)",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Emergency Leave taken By Student(Leave Id 6)",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Emergency Leave taken By Student(Leave Id 6)",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Parent Approved Leave for Hostelleave id 7",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Parent Approved Leave for Hostelleave id 7",
                IsReadChecked = false
            });
            studentlevanotifications.Add(new Studentlevanotificationmodel
            {
                leavenotification = "Parent Approved Leave for Hostelleave id 7",
                IsReadChecked = false
            });
        }
    }
    public class Studentlevanotificationmodel
    {
        public string leavenotification { get; set; }
        public bool IsReadChecked { get; set; }
    }
}
