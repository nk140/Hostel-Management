using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Parent
{
    public class UpdatePasswordVM : BaseViewModel, iUpdatePassword
    {
        ParentService web;
        private UpdatePassword updatePassword = new UpdatePassword();
        private string cnfpassword;
        public UpdatePassword UpdatePassword
        {
            get
            {
                return updatePassword;
            }
            set
            {
                updatePassword = value;
                OnPropertyChanged("updatePassword");
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
            web = new ParentService((iUpdatePassword)this);
        }
        public async void OnUpdatePasswordCommand()
        {
            if (string.IsNullOrEmpty(UpdatePassword.password)||UpdatePassword.password.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Password", "OK");
            else if (string.IsNullOrEmpty(Cnfpassword) || Cnfpassword.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter confirm password", "OK");
            else if(UpdatePassword.password!=Cnfpassword)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Password Mismatch", "OK");
            }
            else
            {
                UpdatePassword.userId = App.userid;
                web.SetPassword(UpdatePassword);
            }
        }
        public async void servicefailed(string result)
        { 
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void UpdatepasswordSuccess(string result)
        {
            UpdatePassword = new UpdatePassword();
            Cnfpassword = "";
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdatePassword");
            OnPropertyChanged("Cnfpassword");
        }
    }
}
