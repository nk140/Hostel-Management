using HMS.ViewModel.Admin;
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
    public partial class ViewHostelByArea : PopupPage
    {
        ViewFilteredHostelVM vm;
        public ViewHostelByArea()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredHostelVM();
        }

        private async void btnviewhostelbyarea_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewHostel(App.areaid));
        }

        private void ddarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.areaid = ddarea.Items[ddarea.SelectedIndex];
        }
    }
}