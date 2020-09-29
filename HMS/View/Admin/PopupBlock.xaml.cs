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
    public partial class PopupBlock : PopupPage
    {
        ViewFilteredBlockVM vm;
        string no;
        public PopupBlock()
        {
            InitializeComponent();
        }
        public PopupBlock(string areaid)
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredBlockVM();
        }
        private async void btnblockfilterapply_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopPopupAsync(true);
           // await App.Current.MainPage.Navigation.PushModalAsync(new ViewBlock(no));
        }

        private void ddgender11_SelectedIndexChanged(object sender, EventArgs e)
        {
            no = ddgender11.Items[ddgender11.SelectedIndex];
        }
    }
}