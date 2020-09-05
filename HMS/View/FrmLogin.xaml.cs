using HMS.Interface;
using HMS.View.Guest;
using HMS.View.Parrent;
using HMS.View.Student;
using HMS.View.Warden;
using HMS.ViewModel;
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
            var actionSheet = await DisplayActionSheet("Registration for which Role.", "Guest", null, "Parent", "Student");
            switch (actionSheet)
            {
                case "Guest":
                    TapGestureRecognizer_Tapped_1();
                    break;
                case "Parent":
                    TapGestureRecognizer_Tapped_2();
                    break;
                case "Student":
                    TapGestureRecognizer_Tapped_3();
                    break;
            }
            //Application.Current.MainPage = new NavigationPage(new View.Student.FrmStudentRegistration());
        }
        private async void TapGestureRecognizer_Tapped_1()
        {
            Application.Current.MainPage = new NavigationPage(new FrmGuestRegistration());
        }
        private async void TapGestureRecognizer_Tapped_2()
        {
            //Application.Current.MainPage = new NavigationPage(new View.Student.Frm());
        }
        private async void TapGestureRecognizer_Tapped_3()
        {
            Application.Current.MainPage = new NavigationPage(new FrmStudentRegistration());
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ForgetPassword(), true);
        }
    }
}
