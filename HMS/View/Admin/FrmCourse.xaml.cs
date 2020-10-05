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
    public partial class FrmCourse : ContentPage
    {
        CreateCourseVM vm;
        public FrmCourse()
        {
            InitializeComponent();
            BindingContext = vm = new CreateCourseVM();
        }
    }
}