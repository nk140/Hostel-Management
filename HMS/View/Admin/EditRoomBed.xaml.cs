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
    public partial class EditRoomBed : ContentPage
    {
        EditRoomBedVM vm;
        public EditRoomBed()
        {
            InitializeComponent();
        }
        public EditRoomBed(string roomname, string bedId, string bedNo, string hostelRoomId, string hostelId)
        {
            InitializeComponent();
            BindingContext = vm = new EditRoomBedVM(roomname, bedId,bedNo,hostelRoomId, hostelId);
        }
    }
}