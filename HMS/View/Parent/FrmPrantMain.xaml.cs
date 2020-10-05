using HMS.Models;
using HMS.View.Student;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parrent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmPrantMain : MasterDetailPage
    {
        public ObservableCollection<ParentMenuItem> parentmenuList { get; set; }
        public FrmPrantMain()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            parentmenuList = new ObservableCollection<ParentMenuItem>
            {
                new ParentMenuItem {Title="News Feed",TargetType=typeof(FrmParentNewsFeed)},
                //new ParentMenuItem {Title="Parent Registration",TargetType=typeof(FrmParentRegistration) },
                new ParentMenuItem {Title="Hostel Detail",TargetType=typeof(FrmParentHostelDetails)},
                new ParentMenuItem {Title="Student Detail",TargetType=typeof(FrmParentStudentDetails)},
                new ParentMenuItem {Title="Roomates",TargetType=typeof(FrmParentRoomates)},
                //new ParentMenuItem {Title="Leave Applied",TargetType=typeof(FrmParentLeaves)},
                new ParentMenuItem {Title="Warden Details",TargetType=typeof(FrmWardenDetails)},
                new ParentMenuItem {Title="Logout",TargetType=typeof(FrmLogin)},
            };
            ListParentMn.ItemsSource = parentmenuList;
            //Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FrmParentRegistration)));
        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ParentMenuItem;
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
                    item.Selected = false;
                    item.ItemColor = Color.Black;
                    Type page = item.TargetType;
                    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                    IsPresented = false;
                }
            }
        }

        private void user_Clicked(object sender, EventArgs e)
        {

        }

        private async void studentleavenotification_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new StudentNotificationxaml());
        }
    }
}
