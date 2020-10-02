using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class UpdatePasswordVM : BaseViewModel, Iupdatestudentpassword
    {
        StudentService web;
        private UpdateStudPassword updateStudPassword = new UpdateStudPassword();
        private string cnfpassword;
        public UpdateStudPassword UpdateStudPassword
        {
            get
            {
                return updateStudPassword;
            }
            set
            {
                updateStudPassword = value;
                OnPropertyChanged("UpdateStudPassword");
            }
        }
        public string Cnfpassword
        {
            get
            {
                return cnfpassword;
            }
            set
            {
                cnfpassword = value;
                OnPropertyChanged("Cnfpassword");
            }
        }
        public ICommand UpdatePasswordCommand => new Command(OnUpdatePasswordCommand);
        public UpdatePasswordVM()
        {
            web = new StudentService((Iupdatestudentpassword)this);
        }
        public async void OnUpdatePasswordCommand()
        {
            if (string.IsNullOrEmpty(UpdateStudPassword.password) || UpdateStudPassword.password.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Password", "OK");
            else if (string.IsNullOrEmpty(Cnfpassword) || Cnfpassword.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter confirm password", "OK");
            else if (UpdateStudPassword.password != Cnfpassword)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Password Mismatch", "OK");
            }
            else
            {
                UpdateStudPassword.studentId = App.userid;
                web.UpdateStudentPassword(UpdateStudPassword);
            }
        }
        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void UpdatedSucessfully(string result)
        {
            UpdateStudPassword = new UpdateStudPassword();
            Cnfpassword = "";
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdatePassword");
            OnPropertyChanged("Cnfpassword");
        }
    }
}
