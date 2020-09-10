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
                OnPropertyChanged();
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
            if(IsCheck1==true)
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
            else if (GuestRegistrationModel.userName == null || GuestRegistrationModel.userName.Length == 0)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Username", "OK");
            }
            else
            {
                Sendsms();
                GuestRegistrationModel.password = temppassword;
                guestServices.SaveGuestData(GuestRegistrationModel);
            }
        }
        public async void GenerateRandomPassword()
        {
            int length = 4;
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            temppassword = str_build.ToString();
        }
        public async void Sendsms()
        {
             GenerateRandomPassword();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("nk8059168@gmail.com");
                mail.To.Add(GuestRegistrationModel.email);
                mail.Subject = "New Password";
                mail.Body = "Hello" +" "+ GuestRegistrationModel.userName + " " + "You Have Sucessfully Registered and your password is" + " " + temppassword;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("nk8059168@gmail.com", "Nitesh935@");
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
        public async void Success(string result)
        {
            GuestRegistrationModel = new GuestRegistrationModel();
            IsCheck1 = true;
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("GuestRegistrationModel");
        }
    }
}
