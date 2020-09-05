using dotMorten.Xamarin.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frmcallguest : ContentPage
    {
        public Frmcallguest()
        {
            InitializeComponent();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {

        }

        private void txtsearchbykeyword_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {

        }
    }
}