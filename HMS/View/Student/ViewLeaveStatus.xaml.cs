using HMS.ViewModel.Warden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewLeaveStatus : ContentPage
    {
        ViewStudentLeaveStatus vm;
        public ViewLeaveStatus()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewStudentLeaveStatus();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}