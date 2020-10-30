
using HMS.ViewModel.Parent;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parrent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmParentStudentDetails : ContentPage
    {
        ParentProfileVM vm;
        public FrmParentStudentDetails()
        {
            InitializeComponent();
            childname.Text = "Name:-"+" "+SecureStorage.GetAsync("studentName").GetAwaiter().GetResult();
            childroomno.Text = "Room Name:-" + " " + SecureStorage.GetAsync("roomName").GetAwaiter().GetResult();
            childbedno.Text="Bed No:-"+" "+ SecureStorage.GetAsync("roomBedName").GetAwaiter().GetResult();
            blockno.Text="Block Name:-"+" "+ SecureStorage.GetAsync("blockName").GetAwaiter().GetResult();
            hostelname.Text="Hostel name:-"+" "+ SecureStorage.GetAsync("hostelName").GetAwaiter().GetResult();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ParentProfileVM();
            //childname.Text = "Name:-" + " " + SecureStorage.GetAsync("studentName").GetAwaiter().GetResult();
            //childroomno.Text = "Room Name:-" + " " + SecureStorage.GetAsync("roomName").GetAwaiter().GetResult();
            //childbedno.Text = "Bed No:-" + " " + SecureStorage.GetAsync("roomBedName").GetAwaiter().GetResult();
            //blockno.Text = "Block Name:-" + " " + SecureStorage.GetAsync("blockName").GetAwaiter().GetResult();
            //hostelname.Text = "Hostel name:-" + " " + SecureStorage.GetAsync("hostelName").GetAwaiter().GetResult();
        }
    }
}