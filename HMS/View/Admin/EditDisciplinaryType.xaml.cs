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
    public partial class EditDisciplinaryType : ContentPage
    {
        EditDisciplinaryTypeVM vm;
        public EditDisciplinaryType()
        {
            InitializeComponent();
        }
        public EditDisciplinaryType(string id,string disciplinaryname,string userid)
        {
            InitializeComponent();
            BindingContext = vm = new EditDisciplinaryTypeVM(id,disciplinaryname,userid);
        }
    }
}