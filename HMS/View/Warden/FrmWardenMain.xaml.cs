using HMS.Models;
using HMS.View.Admin;
using HMS.View.Guest;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmWardenMain : MasterDetailPage
    {
        public ObservableCollection<WardenMenuItem> wardenmenuList { get; set; }
        public FrmWardenMain()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            user.Text = SecureStorage.GetAsync("firstName").GetAwaiter().GetResult();
            wardenmenuList = new ObservableCollection<WardenMenuItem>
            {
                new WardenMenuItem {Title="News Feed.",TargetType=typeof(AdminNewsFeed)},
                new WardenMenuItem {Title="Set Password.",TargetType=typeof(SetPassword)},
                 //new WardenMenuItem {Title="Warden Registration.",TargetType=typeof(FrmWardenRegistration) },
                new WardenMenuItem {Title="View Hostel Detail.",TargetType=typeof(FrmHostelDetail)},
                new WardenMenuItem {Title="New Student Detail.",TargetType=typeof(FrmViewNewStudent)},
                //new WardenMenuItem {Title="Contact Student",TargetType=typeof(FrmStudentContact)},
                new WardenMenuItem {Title="Contact From Student Parent.",TargetType=typeof(FrmStudentParentContact)},
               // new WardenMenuItem {Title="Contact Director.",TargetType=typeof(FrmDirectorcontact)},
                new WardenMenuItem {Title="Disciplinary Option",TargetType=typeof(FrmDiscpoption)},
                new WardenMenuItem {Title="View Disciplinary Action",TargetType=typeof(ViewDisciplinaryAction)},
                new WardenMenuItem {Title="Student Leave(Approve/Reject)",TargetType=typeof(Frmstudentleaveaction)},
                new WardenMenuItem {Title="Student Leave History.",TargetType=typeof(FrmStudleavehistory)},
                new WardenMenuItem {Title="Upload Room Image/Video.",TargetType=typeof(FrmImagevideoupload)},
               // new WardenMenuItem {Title="Student Check-In/Check-Out.",TargetType=typeof(Frmstudentcheckinout)},
                //new WardenMenuItem {Title="Assign Driver For Vehicle.",TargetType=typeof(Frmassignvehicledriver)},
                //new WardenMenuItem {Title="View Driver Request & Assign(Pickup & Drop)",TargetType=typeof(Frmviewdriverrequest)},
                //new WardenMenuItem {Title="Contact Person(Requested for Pickup & Drop Service)",TargetType=typeof(Frmcontactperson)},
                new WardenMenuItem {Title="Service Category.",TargetType=typeof(Frmservicecategory)},
                //new WardenMenuItem {Title="View Service Request & assign Service Person.",TargetType=typeof(Frmviewservicerequest)},
                //new WardenMenuItem {Title="View Service Status.",TargetType=typeof(Frmviewservicestatus)},
               // new WardenMenuItem {Title="Contact With Students.",TargetType=typeof(Frmstudentscontact)},
                //new WardenMenuItem {Title="View Service Feedback.",TargetType=typeof(Frmservicefeedback)},
                //new WardenMenuItem {Title="View Guest Booking Detail & Approve.",TargetType=typeof(Frmviewguestbookingapprove)},
                new WardenMenuItem {Title="Call Guest.",TargetType=typeof(Frmcallguest)},
                new WardenMenuItem {Title="Logout",TargetType=typeof(FrmLogin)},
            };
            ListViewMenu.ItemsSource = wardenmenuList;
        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as WardenMenuItem;
            if (item != null)
            {
                if (item.Title == "Logout")
                {
                    item.Selected = false;
                    SecureStorage.RemoveAll();
                    App.userid = null;
                    Application.Current.MainPage = new FrmLogin();
                }
                else
                {
                    item.Selected = true;
                    Type page = item.TargetType;
                    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                    IsPresented = false;
                }
            }
        }

        private async void studentleaveapproval_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Notificationcenter(), true);
        }

        private async void user_Clicked(object sender, EventArgs e)
        {

        }
    }
}