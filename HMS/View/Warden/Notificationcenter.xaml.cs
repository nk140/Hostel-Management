using HMS.ViewModel.Warden;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notificationcenter : PopupPage
    {
        NotificationVM vm;
        public Notificationcenter()
        {
            InitializeComponent();
            BindingContext = vm = new NotificationVM();
        }
    }
}