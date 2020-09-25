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
    public partial class AreaMaster : PopupPage
    {
        public AreaMaster()
        {
            InitializeComponent();
        }

        private async void btnviewarea_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ViewArea());
        }

        private async void btnnewarea_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FrmArea());
        }
    }
}