
using HMS.ViewModel.Warden;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parrent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmParentLeaves : ContentPage
    {
        ViewWardLeaveHistoryVM vm;
        string studentid, hosteladmissionid;
        public FrmParentLeaves()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            studentid= SecureStorage.GetAsync("studentId").GetAwaiter().GetResult();
            hosteladmissionid= SecureStorage.GetAsync("hostelAdmisiionId").GetAwaiter().GetResult();
            BindingContext = vm = new ViewWardLeaveHistoryVM(studentid, hosteladmissionid);
        }
    }
}