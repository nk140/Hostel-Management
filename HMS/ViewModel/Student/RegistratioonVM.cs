using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class RegistratioonVM : BaseViewModel, RegistrationI
    {
        public RegistratioonVM()
        {
            Registration = new RegistrationModel();
            web = new StudentService(this);
        }

        StudentService web;
        RegistrationModel registration_ = new RegistrationModel();
        string confirmPassword_;

        public RegistrationModel Registration
        {
            get { return registration_; }
            set { registration_ = value; OnPropertyChanged("Registration"); }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword_; }
            set { confirmPassword_ = value; OnPropertyChanged("ConfirmPassword"); }
        }

        bool Validate()
        {
            if (Registration.studentName == null || Registration.studentName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Name", "OK");
                return false;
            }
            else if (Registration.address == null || Registration.address.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Address", "OK");
                return false;
            }
            else if (Registration.phoneNo == null || Registration.phoneNo.ToString().Trim().Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Phone Number", "OK");
                return false;
            }
            else if (Registration.email == null || Registration.email.ToString().Trim().Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Emaiil Id", "OK");
                return false;
            }
            else if (Registration.adharNo == null || Registration.adharNo.ToString().Trim().Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Adhar No", "OK");
                return false;
            }
            else if (Registration.userName == null || Registration.userName.ToString().Trim().Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Username", "OK");
                return false;
            }
            else if (Registration.password == null || Registration.password.ToString().Trim().Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Enter Password", "OK");
                return false;
            }
            else if (ConfirmPassword == null || Registration.password.ToString().Trim() != ConfirmPassword)
            {
                App.Current.MainPage.DisplayAlert("", "Password and Confirm Password is missmatch", "OK");
                return false;
            }
            return true;
        }



        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Validate())
                    {
                        web.SaveStudentRegister(Registration);
                    }

                });
            }
        }


        public async Task ServiceFaild()
        {
            await App.Current.MainPage.DisplayAlert("HMS", "Server Error", "OK");
        }

        public async Task RegistrationSuccess(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "Registration Successfully.", "OK");
            await App.Current.MainPage.Navigation.PopModalAsync(true);
        }
    }
}
