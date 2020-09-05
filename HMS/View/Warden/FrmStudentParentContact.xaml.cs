using dotMorten.Xamarin.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmStudentParentContact : ContentPage
    {
        public FrmStudentParentContact()
        {
            InitializeComponent();
        }

        private void txtsearchbykeyword_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {

        }

        private void txtsearchbykeyword_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {

        }
    }
}