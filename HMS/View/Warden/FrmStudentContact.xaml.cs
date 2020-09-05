
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmStudentContact : ContentPage
    {
        public FrmStudentContact()
        {
            InitializeComponent();
            //lv_contact.ItemsSource = StudentList.student;
        }
    }
}