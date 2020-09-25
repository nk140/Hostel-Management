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
    public partial class EditServiceCategory : ContentPage
    {
        EditServiceCategoryVM vm;
        public EditServiceCategory()
        {
            InitializeComponent();
        }
        public EditServiceCategory(string id,string name,string userid)
        {
            InitializeComponent();
            BindingContext = vm = new EditServiceCategoryVM(id, name, userid);
        }
    }
}