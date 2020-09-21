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
    public partial class ViewFloor : ContentPage
    {
        ViewFloorVM vm;
        public ViewFloor()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFloorVM();
            FloorDetaillists1.ItemsSource = vm.FloorDetaillists;
        }
    }
}