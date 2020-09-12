using HMS.View.Guest;
using HMS.View.Parent;
using HMS.View.Student;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationOption : PopupPage
    {
        public RegistrationOption()
        {
            InitializeComponent();
        }

        private void guest_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopPopupAsync(true);
            Application.Current.MainPage = new NavigationPage(new FrmGuestRegistration());
        }

        private void student_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopPopupAsync(true);
            Application.Current.MainPage = new NavigationPage(new FrmStudentRegistration());
        }

        private void parent_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopPopupAsync(true);
            Application.Current.MainPage = new NavigationPage(new FrmParentRegistrationBeforLogin());
        }
    }
}