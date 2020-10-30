using HMS.ViewModel.Warden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewServiceStatus : ContentPage
    {
        ServiceStatusbypersonVM vm;
        public ViewServiceStatus()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ServiceStatusbypersonVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}