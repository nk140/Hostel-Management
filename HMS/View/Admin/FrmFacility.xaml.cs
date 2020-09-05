using HMS.ViewModel.Admin;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmFacility : ContentPage
    {
        public FrmFacility()
        {
            InitializeComponent();
        }

        FasilityVM Vm;

        protected override void OnAppearing()
        {
            Vm = new FasilityVM();
            BindingContext = Vm;
        }
    }
}
