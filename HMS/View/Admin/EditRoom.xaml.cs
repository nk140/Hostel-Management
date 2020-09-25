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
    public partial class EditRoom : ContentPage
    {
        EditRoomVM vm;
        public EditRoom()
        {
            InitializeComponent();
        }
        public EditRoom(string id, string name, string hostelid,string hostelroomtypeid,string blockid,string floorid,string noOfBed)
        {
            InitializeComponent();
            BindingContext = vm = new EditRoomVM(id, name, hostelid, hostelroomtypeid, blockid, floorid, noOfBed);
        }
    }
}