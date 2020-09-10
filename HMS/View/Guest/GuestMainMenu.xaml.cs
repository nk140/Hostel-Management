using HMS.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestMainMenu : MasterDetailPage
    {
        public ObservableCollection<GuestMenu> guestmenulist { get; set; }
        public GuestMainMenu()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            guestmenulist = new ObservableCollection<GuestMenu>
            {
                new GuestMenu {Title="News Feed",TargetType=typeof(NewsFeed)},
                new GuestMenu {Title="Guest Registration",TargetType=typeof(GuestRegistration)},
                // new GuestMenu {Title="Room Detail",TargetType=typeof(GuestRoomDetails)},
                //  new GuestMenu {Title="View Room Image & Video",TargetType=typeof(Imagevideoview)},
                   new GuestMenu {Title="Facility Details",TargetType=typeof(RoomFacility)},
                    new GuestMenu {Title="Request for room & view status",TargetType=typeof(Roombookingandstatusview)},
                //new GuestMenu {Title="Contact Warden",TargetType=typeof(Contactwarden)},
                new GuestMenu {Title="Logout",TargetType=typeof(FrmLogin)}
            };
            ListViewMenu.ItemsSource = guestmenulist;
        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as GuestMenu;
            if (item != null)
            {
                if (item.Title == "Logout")
                {
                    item.Selected = false;
                    SecureStorage.RemoveAll();
                    Application.Current.MainPage = new FrmLogin();
                }
                else
                {
                    Type page = item.TargetType;
                    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                    IsPresented = false;
                }
            }
        }
    }
}