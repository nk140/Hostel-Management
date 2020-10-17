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
    public partial class CreateLeavetype : ContentPage
    {
        CreateLeaveTypeVM vm;
        public CreateLeavetype()
        {
            InitializeComponent();
            BindingContext = vm = new CreateLeaveTypeVM();
        }
    }
}