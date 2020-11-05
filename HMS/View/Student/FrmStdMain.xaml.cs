using HMS.Models;
using Rg.Plugins.Popup.Extensions;
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
                new StudentMenuItem {Title="Set Password",TargetType=typeof(SetPassword)},
                new StudentMenuItem {Title="Profile",TargetType=typeof(FrmStudentProfile)},
                //new StudentMenuItem {Title="Roomate Details",TargetType=typeof(FrmRoomMateDetails)},
                new StudentMenuItem {Title="Hostel Admission",TargetType=typeof(StudentHostelAdmission)},
                new StudentMenuItem {Title="View Disciplinary Action",TargetType=typeof(ViewDisciplinaryAction)},
                new StudentMenuItem {Title="Room List",TargetType=typeof(FrmRoomList)},
                  new StudentMenuItem {Title="Service Request",TargetType=typeof(FrmServiceRequest)},
                   new StudentMenuItem {Title="Leave Request",TargetType=typeof(FrmLeaveApplication)},
                   new StudentMenuItem {Title="View Leave Status",TargetType=typeof(ViewLeaveStatus)},
                   new StudentMenuItem {Title="Vehicle Request",TargetType=typeof(FrmVehicleRequest)},
                   new StudentMenuItem {Title="Service Feedback",TargetType=typeof(Feedbackonservice)},
                   new StudentMenuItem {Title="View Service Status",TargetType=typeof(ViewRequestedServiceStatus)},
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
                    App.userid = null;
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

        private async void studentleaveapproval_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new StudentNotificationxaml());
        }

        private void user_Clicked(object sender, EventArgs e)
        {

        }
    }
}
