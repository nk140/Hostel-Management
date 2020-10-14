
using HMS.ViewModel.Warden;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmStudentContact : ContentPage
    {
        StudentContactforwarden vm;
        public FrmStudentContact()
        {
            InitializeComponent();
            BindingContext = vm = new StudentContactforwarden();
            //lv_contact.ItemsSource = StudentList.student;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new StudentContactforwarden();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbystudentname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {

        }

        private void txtsearchbystudentname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {

        }
    }
}