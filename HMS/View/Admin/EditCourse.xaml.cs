using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCourse : ContentPage
    {
        EditCourseVM vm;
        public EditCourse()
        {
            InitializeComponent();
        }
        public EditCourse(string userid,string courseid,string coursename,string coursecode)
        {
            InitializeComponent();
            BindingContext = vm = new EditCourseVM(userid, courseid, coursename, coursecode);
        }
    }
}