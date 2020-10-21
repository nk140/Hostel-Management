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
    public partial class FloorMaster : ContentPage
    {
        public FloorMaster()
        {
            InitializeComponent();
        }

        private async void btnviewfloor_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewFloorByHostel());
        }

        private async void btnnewfloor_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new FrmFloor());
        }
    }
}