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
            BindingContext = vm = new EditNewsFeedVM();
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
    }
}