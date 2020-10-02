using HMS.Data;
using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class StudentParentInfo : BaseViewModel,iViewParent
    {
        private ObservableCollection<StudentParentDetail> studentParentDetails = new ObservableCollection<StudentParentDetail>();
        WardenService web;
        #region list
        public ObservableCollection<StudentParentDetail> StudentParentDetails
        {
            get
            {
                return studentParentDetails;
            }
            set
            {
                studentParentDetails = value;
                OnPropertyChanged("StudentParentDetails");
            }
        }
        #endregion
        #region Tapcommands
        public ICommand CallCommand => new Command<StudentParentDetail>(OnCallCommand);
        public ICommand MessageCommand => new Command<StudentParentDetail>(OnMessageCommand);
        public ICommand WhatsappCommand => new Command<StudentParentDetail>(OnWhatsappCommand);
        #endregion
        public StudentParentInfo()
        {
            web = new WardenService((iViewParent)this);
            web.GetParentDetails();
        }
        public async void OnCallCommand(StudentParentDetail guestModel)
        {
            try
            {
                PhoneDialer.Open(guestModel.parentPhoneNo);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
        public async void OnMessageCommand(StudentParentDetail guestModel)
        {
            try
            {
                var message = new SmsMessage("You Have to come to collect refund money", guestModel.parentPhoneNo);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Sms is not supported on this device.", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failed", ex.Message, "OK");
            }
        }
        public async void OnWhatsappCommand(StudentParentDetail guestModel)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + guestModel.parentPhoneNo));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }

        public void LoadParentData(ObservableCollection<StudentParentDetail> studentParentDetails)
        {
            StudentParentDetails = studentParentDetails;
            OnPropertyChanged("StudentParentDetails");
        }

        public void Servicefailed(string result)
        {
           
        }
    }
}
