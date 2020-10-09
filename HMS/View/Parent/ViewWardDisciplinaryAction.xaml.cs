using HMS.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewWardDisciplinaryAction : ContentPage
    {
        ViewWardDisciplinaryActionVM vm;
        public ViewWardDisciplinaryAction()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewWardDisciplinaryActionVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}