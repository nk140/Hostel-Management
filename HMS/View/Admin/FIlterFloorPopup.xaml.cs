using HMS.ViewModel.Admin;
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
    public partial class FIlterFloorPopup : PopupPage
    {
        ViewFilteredFloorVM vm;
        string no;
        public FIlterFloorPopup()
        {
            InitializeComponent();
        }
        public FIlterFloorPopup(string areaid)
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredFloorVM();
        }
        private async void btnapply_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopPopupAsync(true);
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewFloor());
        }

        private void ddgenders_SelectedIndexChanged(object sender, EventArgs e)
        {
            no = ddgenders.Items[ddgenders.SelectedIndex];
        }
    }
}