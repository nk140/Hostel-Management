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

        private void BtnLoginClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new FrmLogin();
        }
    }
}
