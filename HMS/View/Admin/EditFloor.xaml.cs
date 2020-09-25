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
    public partial class EditFloor : ContentPage
    {
        EditFloorVM vm;
        public EditFloor()
        {
            InitializeComponent();
        }
        public EditFloor(string floorId,string floorName,string hostelId,string noOfRooms,string blocks_id)
        {
            InitializeComponent();
            BindingContext = vm = new EditFloorVM(floorId, floorName, hostelId, noOfRooms, blocks_id);
        }
    }
}