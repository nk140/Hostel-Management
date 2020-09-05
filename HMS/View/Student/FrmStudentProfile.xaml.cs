using HMS.ViewModel.Student;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmStudentProfile : ContentPage
    {
        public FrmStudentProfile()
        {
            InitializeComponent();
        }

        ProfileVM Vm;

        protected override void OnAppearing()
        {
            Vm = new ProfileVM();
            BindingContext = Vm;
        }
    }
}
