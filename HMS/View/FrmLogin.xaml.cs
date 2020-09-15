using HMS.Interface;
using HMS.View.Guest;
using HMS.View.Parrent;
using HMS.View.Student;
using HMS.View.Warden;
using HMS.ViewModel;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.View
{
    public partial class FrmLogin : ContentPage, NavigationPageI
    {
        LoginViewModel Vm;
        public FrmLogin()
        {
            InitializeComponent();
            Vm = new LoginViewModel(this);
            BindingContext = Vm;
            // Application.Current.MainPage = new MainPage();
        }
        public async Task NavigateHomeForm()
        {
            var usertype = Convert.ToString(SecureStorage.GetAsync("type").GetAwaiter().GetResult());
            if (usertype == "student")
            {
                App.userid= Convert.ToString(SecureStorage.GetAsync("userId").GetAwaiter().GetResult());
                Application.Current.MainPage = new Student.FrmStdMain();
            }
            else if (usertype == "warden")
                Application.Current.MainPage = new FrmWardenMain();
            else if (usertype == "parent")
                Application.Current.MainPage = new FrmPrantMain();
            else if (usertype == "admin")
                Application.Current.MainPage = new Admin.FrmMainPage();
            else if (usertype == "guest")
                Application.Current.MainPage = new GuestMainMenu();
            else
                Application.Current.MainPage = new FrmRoommateDetails();
        }
        private async void BtnRegisterClick(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new RegistrationOption(), true);
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ForgetPassword(), true);
        }
    }
}
