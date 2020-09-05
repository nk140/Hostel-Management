using HMS.ViewModel.Admin;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmRoomType : ContentPage
    {
        public FrmRoomType()
        {
            InitializeComponent();
        }

        RoomTypeVM Vm;

        protected override void OnAppearing()
        {
            Vm = new RoomTypeVM();
            BindingContext = Vm;
        }
    }
}
