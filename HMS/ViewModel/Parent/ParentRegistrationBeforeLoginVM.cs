using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Parent
{
    public class ParentRegistrationBeforeLoginVM : BaseViewModel, Iparent
    {
        ParentRegistration parentRegistrations = new ParentRegistration();
        private string cnfpassword;
        ParentService parentService;
        #region properties
        public ParentRegistration ParentRegistrations
        {
            get
            {
                return parentRegistrations;
            }
            set
            {
                parentRegistrations = value;
                OnPropertyChanged("ParentRegistrations");
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
        #endregion
        #region Commands
        public ICommand SaveCommands => new Command(OnSaveCommands);
        #endregion
        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void Success(string result)
        {
            ParentRegistrations = new ParentRegistration();
            Cnfpassword = string.Empty;
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("ParentRegistrations");
            OnPropertyChanged("Cnfpassword");
        }
        public async void OnSaveCommands()
        {
            if(validate())
            {
                parentService.SaveParentDetail(ParentRegistrations);
            }
        }
        bool validate()
        {
            string emailpattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex emailRegx = new Regex(emailpattern);
            if (string.IsNullOrEmpty(ParentRegistrations.parentName) || ParentRegistrations.parentName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Parent Name", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(ParentRegistrations.aadharNo) || ParentRegistrations.aadharNo.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Aaadhar no", "OK");
                return false;
            }
            else if (ParentRegistrations.aadharNo.Length != 12)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter 12 digit aadhar no", "OK");
                return false;
            }
            else if (ParentRegistrations.address.Length == 0 || string.IsNullOrEmpty(ParentRegistrations.address))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Address", "OK");
                return false;
            }
            else if (ParentRegistrations.email.Length == 0 || string.IsNullOrEmpty(ParentRegistrations.email))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter email address", "OK");
                return false;
            }
            else if (emailRegx.IsMatch(ParentRegistrations.email) == false)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter valid email address", "OK");
                return false;
            }
            else if (ParentRegistrations.parentPhoneNo.Length == 0 || string.IsNullOrEmpty(ParentRegistrations.parentPhoneNo))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter phone no", "OK");
                return false;
            }
            else if (ParentRegistrations.parentPhoneNo.StartsWith("1") || ParentRegistrations.parentPhoneNo.StartsWith("2") || ParentRegistrations.parentPhoneNo.StartsWith("3") || ParentRegistrations.parentPhoneNo.StartsWith("4") || ParentRegistrations.parentPhoneNo.StartsWith("5"))
            {
                App.Current.MainPage.DisplayAlert("", "Enter Valid Phone Number", "OK");
                return false;
            }
            else if (parentRegistrations.parentPhoneNo.Length != 10)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter 10 digit phone no", "OK");
                return false;
            }
            else if (ParentRegistrations.userName.Length == 0 || string.IsNullOrEmpty(ParentRegistrations.userName))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter username", "OK");
                return false;
            }
            else if(ParentRegistrations.password.Length == 0 || string.IsNullOrEmpty(ParentRegistrations.password))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Please enter password", "OK");
                return false;
            }
            else if(Cnfpassword.Length==0 || string.IsNullOrEmpty(Cnfpassword))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Confirm password", "OK");
                return false;
            }
            else if(ParentRegistrations.password!=Cnfpassword)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Password is not matched", "OK");
                return false;
            }
            return true;
        }
        public ParentRegistrationBeforeLoginVM()
        {
            parentService = new ParentService(this);
        }
    }
}
