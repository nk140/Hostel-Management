using HMS.ViewModel.Admin;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmServiceCategoryCreatioon : ContentPage
    {
        public FrmServiceCategoryCreatioon()
        {
            InitializeComponent();
        }

        ServiceCategoryVM Vm;

        protected override void OnAppearing()
        {
            Vm = new ServiceCategoryVM();
            BindingContext = Vm;
        }
    }
}
