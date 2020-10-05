using dotMorten.Xamarin.Forms;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmDiscpoption : ContentPage
    {
        public FrmDiscpoption()
        {
            InitializeComponent();
        }

        private void txtdisciplinarytype_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {

        }

        private void txtdisciplinarytype_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {

        }

        private void txtstudentregistrationno_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {

        }

        private void txtstudentregistrationno_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {

        }

        private void dtofaction_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void timeofaction_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}