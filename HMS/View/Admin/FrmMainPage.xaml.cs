using HMS.Models;
using HMS.View.Student;
using HMS.View.Warden;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmMainPage : MasterDetailPage
    {
        public ObservableCollection<HomeMenuItem> menuItems { get; set; }
        public FrmMainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            menuItems = new ObservableCollection<HomeMenuItem>
            {
                new HomeMenuItem {Title="News Feed",TargetType=typeof(AdminNewsFeed)},
                //new HomeMenuItem {Title="Area Creation",TargetType=typeof(FrmArea)},
                new HomeMenuItem {Title="Area Master",TargetType=typeof(AreaMaster)},
                new HomeMenuItem {Title="Hostel Master",TargetType=typeof(HostelMaster)},
                new HomeMenuItem {Title="Block Master",TargetType=typeof(BlockMaster)},
                new HomeMenuItem {Title="Room Master",TargetType=typeof(RoomMaster)},
                new HomeMenuItem {Title="Room Bed Master",TargetType=typeof(RoomBedMaster)},
                 //new HomeMenuItem {Title="Hostel",TargetType=typeof(FrmHostel)},
                 // new HomeMenuItem {Title="Block",TargetType=typeof(FrmBloack)},
                 //  new HomeMenuItem {Title="Floor",TargetType=typeof(FrmFloor)},
                 //   new HomeMenuItem {Title="Room",TargetType=typeof(FrmRoom)},
                 //   new HomeMenuItem {Title="Room Bed",TargetType=typeof(FrmRoomBed)},
                    new HomeMenuItem {Title="Contact Student Parent",TargetType=typeof(FrmStudentParentContact)},
                    new HomeMenuItem {Title="Warden Assignment",TargetType=typeof(WardenAssignment)},
                    new HomeMenuItem {Title="Contact warden",TargetType=typeof(FrmContactWarden)},
                    new HomeMenuItem {Title="Service Category Master",TargetType=typeof(ServiceCategoryMaster)},
                    //new HomeMenuItem {Title="Service Category",TargetType=typeof(FrmServiceCategoryCreatioon)},
                    new HomeMenuItem{Title="Disciplinary type",TargetType=typeof(Disciplinary)},
                    new HomeMenuItem {Title="Facility",TargetType=typeof(FrmFacility)},
                    new HomeMenuItem {Title="Room Type",TargetType=typeof(FrmRoomType)},
                    new HomeMenuItem {Title="Student Leave Status",TargetType=typeof(Frmstudentleaveaction)},
                    new HomeMenuItem {Title="Upload Hostel Images and Videos",TargetType=typeof(UploadImageAndVideo)},
                    new HomeMenuItem {Title="Create Warden",TargetType=typeof(FrmWardenCreatioin)},
                    new HomeMenuItem {Title="Call Guest",TargetType=typeof(Frmcallguest)},
                new HomeMenuItem {Title="Logout",TargetType=typeof(FrmLogin)}
            };
            ListViewMenu.ItemsSource = menuItems;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(AdminNewsFeed)));  
        }
        private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomeMenuItem;
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

        private async void studentleavenotification_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Notificationcenter(), true);
        }
        private void user_Clicked(object sender, EventArgs e)
        {

        }
    }
}
