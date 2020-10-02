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
    public partial class DisciplinaryMaster : PopupPage
    {
        public DisciplinaryMaster()
        {
            InitializeComponent();
        }

        private async void btnviewdisciplinary_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewDisciplinaryType(), true);
        }

        private async void btnnewdisciplinary_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Disciplinary(), true);
        }
    }
}