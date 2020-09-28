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
    public partial class EditFacility : ContentPage
    {
        EditFacilityVM vm;
        public EditFacility()
        {
            InitializeComponent();
        }
        public EditFacility(string ids, string facilitys, string userids)
        {
            InitializeComponent();
            BindingContext = vm = new EditFacilityVM(ids, facilitys, userids);
        }
    }
}