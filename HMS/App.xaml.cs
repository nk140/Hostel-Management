using HMS.View;
using HMS.View.Admin;
using HMS.View.Guest;
using HMS.View.Parrent;
using HMS.View.Student;
using HMS.View.Warden;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS
{
    public partial class App : Application
    {
        public static string userid;
        public static string studentid;
        public static string studentupdatedphoneno;
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new String[] { "CollectionView_Experimental","SwipeView_Experimental", "RadioButton_Experimental" });
            userid = Convert.ToString(SecureStorage.GetAsync("userId").GetAwaiter().GetResult());
            if (userid == null)
                Application.Current.MainPage = new FrmLogin();
            else
            {
                var usertype = SecureStorage.GetAsync("type").GetAwaiter().GetResult();
                if (usertype == "student")
                {
                    Application.Current.MainPage = new FrmStdMain();
                }
                else if (usertype == "warden")
                    Application.Current.MainPage = new FrmWardenMain();
                else if (usertype == "admin")
                    Application.Current.MainPage = new FrmMainPage();
                else if (usertype == "parent")
                    Application.Current.MainPage = new FrmPrantMain();
                else if (usertype == "guest")
                    Application.Current.MainPage = new GuestMainMenu();
                else
                    App.Current.MainPage.DisplayAlert("HMS", "Entered Credential is Not Available.", "OK");
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
