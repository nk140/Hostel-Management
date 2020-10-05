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
    public partial class EditWarden : ContentPage
    {
        EditWardenVM vm;
        public EditWarden()
        {
            InitializeComponent();
        }
        public EditWarden(string id,string name,string contact)
        {
            InitializeComponent();
            BindingContext = vm = new EditWardenVM(id, name, contact);
        }
    }
}