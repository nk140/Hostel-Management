using HMS.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmStdMain : MasterDetailPage
    {
        public ObservableCollection<StudentMenuItem> studentmenulist { get; set; }
        public FrmStdMain()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            studentmenulist = new ObservableCollection<StudentMenuItem>
            {
                new StudentMenuItem {Title="News Feed",TargetType=typeof(StudentNewsFeed)},
                new StudentMenuItem {Title="Profile",TargetType=typeof(FrmStudentProfile)},
                 new StudentMenuItem {Title="Room List",TargetType=typeof(FrmRoomList)},
                  new StudentMenuItem {Title="Service Request",TargetType=typeof(FrmServiceRequest)},
                   new StudentMenuItem {Title="Leave Request",TargetType=typeof(FrmLeaveApplication)},
                    new StudentMenuItem {Title="Complaint Register",TargetType=typeof(FrmComplaintRegister)},
                new StudentMenuItem {Title="Contact Warden",TargetType=typeof(FrmContactWarden)},
                new StudentMenuItem {Title="Logout",TargetType=typeof(FrmLogin)}
            };
            ListViewMenu.ItemsSource = studentmenulist;
            //Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FrmStudentProfile)));
        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as StudentMenuItem;
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
