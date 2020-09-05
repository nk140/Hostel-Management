using HMS.ViewModel.Warden;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmWardenRegistration : ContentPage
    {
        Wardeninfoupdate vm;
        public FrmWardenRegistration()
        {
            InitializeComponent();
            BindingContext = vm = new Wardeninfoupdate();
            if (vm.Gender != null)
                ddgender.Title = vm.Gender;
            else
                ddgender.Title = "Select Gender";
            if (ddgender.SelectedIndex == 0)
                vm.Gender = "Male";
            else
                vm.Gender = "Female";
        }
    }
}