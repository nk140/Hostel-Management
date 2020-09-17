using HMS.ViewModel.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmParentRegistrationBeforLogin : ContentPage
    {
        ParentRegistrationBeforeLoginVM vm;
        public FrmParentRegistrationBeforLogin()
        {
            InitializeComponent();
            BindingContext = vm = new ParentRegistrationBeforeLoginVM();
        }

        private async void Btnbacklogin_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new FrmLogin();
        }
    }
}