using HMS.ViewModel.Student;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmRoomList : ContentPage
    {
        public FrmRoomList()
        {
            InitializeComponent();
        }

        RoomListVM Vm;

        protected override void OnAppearing()
        {
            Vm = new RoomListVM();
            BindingContext = Vm;
        }
    }
}
