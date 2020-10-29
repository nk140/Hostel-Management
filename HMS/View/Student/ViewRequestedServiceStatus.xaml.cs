using HMS.ViewModel.Student;
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
    public partial class ViewRequestedServiceStatus : ContentPage
    {
        ViewRequestedServiceStatusVM vm;
        public ViewRequestedServiceStatus()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewRequestedServiceStatusVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}