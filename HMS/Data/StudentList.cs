using HMS.Models;
using System.Collections.Generic;

namespace HMS.Data
{
    public class StudentList
    {
        //public  IList<Students> student { get; set; }
        //public StudentList()
        //{
        //    student = new List<Students>();

        //    student.Add(new Students
        //    {
        //        name="Nitesh Kumar",
        //        parentname="MR. N.N. singh",
        //        stream = "MCA",
        //        semester="1st",
        //        contactno="9078802809"
        //    });
        //    student.Add(new Students
        //    {
        //        name = "Navin Kumar",
        //        parentname = "MR.Kishore Kant",
        //        stream = "B.Pharma",
        //        semester="4th",
        //        contactno = "6789098765"
        //    });
        //    student.Add(new Students
        //    {
        //        name = "Vikash Kumar",
        //        parentname = "MR. Arvind Singh",
        //        stream = "MCA",
        //        semester="2nd",
        //        contactno = "9345678909"
        //    });
        //    student.Add(new Students
        //    {
        //        name = "Akhasha Singh",
        //        parentname = "MR. K.N. Singh",
        //        stream = "B.Tech(CSE)",
        //        semester="3rd",
        //        contactno = "9988776655"
        //    });
        //    student.Add(new Students
        //    {
        //        name = "Manoj Singh",
        //        parentname = "MR.N.K.",
        //        stream = "MCA",
        //        semester="5th",
        //        contactno = "6709867234"
        //    });
        //    student.Add(new Students
        //    {
        //        name = "Saurabh sekhar",
        //        parentname = "MR. P.N. Singh",
        //        stream = "B.E",
        //        semester="6th",
        //        contactno = "5788778887"
        //    });
        //    student.Add(new Students
        //    {
        //        name = "Nitesh Rana",
        //        parentname = "MR. N.N. Rana",
        //        stream = "MCA",
        //        semester="4th",
        //        contactno = "9078802877"
        //    });
        //    student.Add(new Students
        //    {
        //        name = "Nitin kumar",
        //        parentname = "MR. Nishant kumar",
        //        stream = "BCA",
        //        semester="3rd",
        //        contactno = "9078802888"
        //    });
        //}
    }
    public class Parentlist
    {
        public IList<Parents> Parent { get; set; }
        public Parentlist()
        {
            Parent = new List<Parents>();
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
        }
    }
}
