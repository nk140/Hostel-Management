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
    public partial class ViewHostel : ContentPage
    {
        ViewHostelVM vm;
        public ViewHostel()
        {
            InitializeComponent();
            BindingContext = vm = new ViewHostelVM();
            viewhostel.ItemsSource = vm.HostelDetaillists;
        }
    }
}