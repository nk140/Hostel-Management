using Rg.Plugins.Popup.Pages;
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
    public partial class LeavetypeMaster : PopupPage
    {
        public LeavetypeMaster()
        {
            InitializeComponent();
        }

        private void btnviewLeavetype_Clicked(object sender, EventArgs e)
        {
             App.Current.MainPage.Navigation.PushModalAsync(new ViewLeaveType());
        }

        private void btnnewleavetype_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new CreateLeavetype());
        }
    }
}