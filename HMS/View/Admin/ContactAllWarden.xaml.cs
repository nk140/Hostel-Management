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
    public partial class ContactAllWarden : ContentPage
    {
        WardenDetailVM vm;
        public ContactAllWarden()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new WardenDetailVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}