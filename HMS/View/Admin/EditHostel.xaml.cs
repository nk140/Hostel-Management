using HMS.Models;
using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditHostel : ContentPage
    {
        EditHostelVM vm;
        public EditHostel()
        {
            InitializeComponent();
        }
        public EditHostel(string hostelid, string hostelname, string areaid, string zipcode, string address, string phone, string email, string genderhostel)
        {
            InitializeComponent();
            BindingContext = vm = new EditHostelVM(hostelid, hostelname, areaid, zipcode, address, phone, email, genderhostel);
        }
    }
}