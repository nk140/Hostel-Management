using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditRoomType : ContentPage
    {
        EditRoomTypeVM vm;
        public EditRoomType()
        {
            InitializeComponent();
        }
        public EditRoomType(string roomids, string userids, string hostelroomtypenames, string hostelids)
        {
            InitializeComponent();
            BindingContext = vm = new EditRoomTypeVM(roomids, userids, hostelroomtypenames, hostelids);
        }
    }
}