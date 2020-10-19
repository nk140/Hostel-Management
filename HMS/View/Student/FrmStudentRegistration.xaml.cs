using HMS.ViewModel.Student;
using System;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmStudentRegistration : ContentPage
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();

            Vm = new RegistratioonVM();
            BindingContext = Vm;
        }
        RegistratioonVM Vm;

        private async void BtnLoginClick(object sender, EventArgs e)
        {
            App.Current.MainPage = new FrmLogin();
        }

        private  void btnhosteladmission_Clicked(object sender, EventArgs e)
        {
             App.Current.MainPage = new StudentHostelAdmission();
        }
    }
}
