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
    public partial class EditBlock : ContentPage
    {
        EditBlockVM vm;
        public EditBlock()
        {
            InitializeComponent();
        }
        public EditBlock(string id,string name,string hostelid,string areaid)
        {
            InitializeComponent();
            BindingContext = vm = new EditBlockVM(id, name,hostelid,areaid);
        }
    }
}