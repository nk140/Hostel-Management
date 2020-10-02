
using HMS.ViewModel.Parent;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parrent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmParentRegistration : ContentPage
    {
        UpdatePasswordVM vm;
        public FrmParentRegistration()
        {
            InitializeComponent();
            BindingContext = vm = new UpdatePasswordVM();
        }
    }
}