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
        #endregion
        public GuestRegBeforeLoginVM()
        {
            guestServices = new GuestServices(this);
        }
        public async void OnSaveCommand()
        {
            string emailpattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex emailRegx = new Regex(emailpattern);
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
        public void GenerateRandomPassword()
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
        public void Sendsms()
        {
             GenerateRandomPassword();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("nk8059168@gmail.com");
                mail.To.Add(GuestRegistrationModel.email);
                mail.Subject = "New Password";
                mail.Body = "Hello" +" "+ GuestRegistrationModel.userName + " " + "You Have Sucessfully Registered and new password is" + " " + temppassword;

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
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("GuestRegistrationModel");
        }
    }
}
