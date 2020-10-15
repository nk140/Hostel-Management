
using HMS.ViewModel.Student;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmVehicleRequest : ContentPage
    {
        VehicleRequestVM vm;
        public FrmVehicleRequest()
        {
            InitializeComponent();
            BindingContext = vm = new VehicleRequestVM();
        }
    }
}
