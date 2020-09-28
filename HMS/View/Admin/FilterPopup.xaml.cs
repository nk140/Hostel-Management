using HMS.Models;
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
    public partial class FilterPopup : PopupPage
    {
        ViewFilteredHostelVM vm;
        string no;
        public FilterPopup()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredHostelVM();
        }

        private async void btnapply_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopPopupAsync(true);
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewHostel(no));
        }

        private void ddgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            no = ddgender.Items[ddgender.SelectedIndex];
            App.filterno = no;
            //no = ddgender.SelectedIndex.ToString();
        }
    }
}