using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Guest
{
    public class GuestRegBeforeLoginVM : BaseViewModel, IGuestRegistration
    {
        private GuestRegistrationModel guestRegistrationModel_ = new GuestRegistrationModel();
        public string cnfpassword;
        public string temppassword;
        GuestServices guestServices;
        #region properties
        public GuestRegistrationModel GuestRegistrationModel
        {
            get
            {
                return guestRegistrationModel_;
            }
            set
            {
                guestRegistrationModel_ = value;
                OnPropertyChanged("GuestRegistrationModel");
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
        #region commands
        public ICommand SaveCommand => new Command(OnSaveCommand);
        public Command Check1Clicked { get; set; }
        public Command Check2Clicked { get; set; }
        #endregion
        bool _check1;
        public bool IsCheck1 { get { return _check1; } set { if (_check1 != value) { _check1 = value; OnPropertyChanged(); } } }
        bool _check2;
        public bool IsCheck2 { get { return _check2; } set { if (_check2 != value) { _check2 = value; OnPropertyChanged(); } } }
        public GuestRegBeforeLoginVM()
        {
            guestServices = new GuestServices(this);
            IsCheck1 = true;
            Check1Clicked = new Command(check1Clicked);
            Check2Clicked = new Command(check2Clicked);
        }
        private void check2Clicked()
        {
            if (IsCheck2 == true)
                IsCheck1 = false;
            else
                IsCheck1 = true;
        }

        private void check1Clicked()
        {
            if (IsCheck1 == true)
            {

                IsCheck2 = false;

            }
            else
            {
                IsCheck2 = true;
            }
        }
        public async void OnSaveCommand()
        {
            string emailpattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex emailRegx = new Regex(emailpattern);
            var result = Cnfpassword;
            if (IsCheck1 == true)
            {
                GuestRegistrationModel.gender = "Male";
            }
            else
            {
                GuestRegistrationModel.gender = "Female";
            }
            if (GuestRegistrationModel.guestName == null || GuestRegistrationModel.guestName.Length == 0)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Name", "OK");
            }
            else if (GuestRegistrationModel.address == null || GuestRegistrationModel.address.Length == 0)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Address", "OK");
            }
            else if (GuestRegistrationModel.phoneNo == null || GuestRegistrationModel.phoneNo.Length == 0)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Address", "OK");
            }
            else if (GuestRegistrationModel.phoneNo.Length != 10)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Phone no should be 10 digits.", "OK");
            }
            else if (GuestRegistrationModel.email == null || GuestRegistrationModel.email.Length == 0)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Email", "OK");
            }
            else if (emailRegx.IsMatch(GuestRegistrationModel.email) == false)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Valid Email Address", "OK");
            }
            else if (GuestRegistrationModel.aadharNo == null || GuestRegistrationModel.aadharNo.Length == 0)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Aadhar no", "OK");
            }
            else if (GuestRegistrationModel.aadharNo.Length != 9)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter 9 digit Aadhar no", "OK");
            else if (GuestRegistrationModel.userName.Length==0 || string.IsNullOrEmpty(GuestRegistrationModel.userName))
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Username", "OK");
            }
            else if (GuestRegistrationModel.password.Length == 0 || string.IsNullOrEmpty(GuestRegistrationModel.password))
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Username", "OK");
            else if (Cnfpassword.Length == 0 || string.IsNullOrEmpty(Cnfpassword))
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Confirm password", "OK");
            else if (GuestRegistrationModel.password != Cnfpassword)
                await App.Current.MainPage.DisplayAlert("HMS", "Password Not match", "OK");
            else
            {
                guestServices.SaveGuestData(GuestRegistrationModel);
            }
        }
        public async void Success(string result)
        {
            GuestRegistrationModel = new GuestRegistrationModel();
            IsCheck1 = true;
            Cnfpassword = string.Empty;
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("GuestRegistrationModel");
            OnPropertyChanged("Cnfpassword");
        }
    }
}
