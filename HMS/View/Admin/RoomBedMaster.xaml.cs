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
    public partial class RoomBedMaster : PopupPage
    {
        public RoomBedMaster()
        {
            InitializeComponent();
        }

        private async void btnviewroombed_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewRoomBedOption(), true);
        }

        private async void btnnewroombed_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new FrmRoomBed());
        }
    }
}