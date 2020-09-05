using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmGuestRegistration : ContentPage
    {
        public FrmGuestRegistration()
        {
            InitializeComponent();
        }

        private void login_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}