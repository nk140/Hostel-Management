using Rg.Plugins.Popup.Extensions;
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
    public partial class RoomMaster : PopupPage
    {
        public RoomMaster()
        {
            InitializeComponent();
        }

        private async void btnviewroom_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewRoomByHostel(), true);
        }

        private async void btnnewroom_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new FrmRoom());
        }
    }
}