using HMS.ViewModel.Student;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmComplaintRegister : ContentPage
    {
        public FrmComplaintRegister()
        {
            InitializeComponent();
        }

        ComplaintRegisterVM Vm;

        protected override void OnAppearing()
        {
            Vm = new ComplaintRegisterVM();
            BindingContext = Vm;
        }



    }
}
