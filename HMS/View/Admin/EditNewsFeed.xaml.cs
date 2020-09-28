using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNewsFeed : ContentPage
    {
        EditNewsFeedVM vm;
        public EditNewsFeed()
        {
            InitializeComponent();
            //BindingContext = vm = new EditNewsFeedVM();
        }
        public EditNewsFeed(string id,string title,string description,string startdates,string lastdates,string linkId)
        {
            InitializeComponent();
            BindingContext = vm = new EditNewsFeedVM(id,title,description,startdates,lastdates,linkId);
        }
        private void dp_start_date_DateSelected(object sender, DateChangedEventArgs e)
        {
            var result= string.Format("{0:yyy-MM-dd}", dp_start_date.Date);
            var finalresult = result + "00:00:00";
            vm.UpdateNewsFeeds.startDate = finalresult;
        }
        private void dp_last_date_DateSelected(object sender, DateChangedEventArgs e)
        {
            var result = string.Format("{0:yyy-MM-dd}", dp_last_date.Date);
            var finalresult = result + "00:00:00";
            vm.UpdateNewsFeeds.lastDate = finalresult;
        }

        private void starttime_Unfocused(object sender, FocusEventArgs e)
        {
            var result = starttime.Time.ToString();
            vm.UpdateNewsFeeds.startTime = result;
        }

        private void endtime_Unfocused(object sender, FocusEventArgs e)
        {
            var result = endtime.Time.ToString();
            vm.UpdateNewsFeeds.lastTime = result;
        }
    }
}