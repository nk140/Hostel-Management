using HMS.Data;
using HMS.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class StudentParentInfo : BaseViewModel
    {
        private ObservableCollection<Parents> parentlist = new ObservableCollection<Parents>();
        Parentlist parentlists1 = new Parentlist();
        #region list
        public ObservableCollection<Parents> Parentlist
        {
            get
            {
                return parentlist;
            }
            set
            {
                parentlist = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Tapcommands
        public ICommand CallCommand => new Command<Parents>(OnCallCommand);
        public ICommand MessageCommand => new Command<Parents>(OnMessageCommand);
        public ICommand WhatsappCommand => new Command<Parents>(OnWhatsappCommand);
        #endregion
        public StudentParentInfo()
        {
            Parentlist = new ObservableCollection<Parents>(parentlists1.Parent);
        }
        public async void OnCallCommand(Parents guestModel)
        {
            try
            {
                PhoneDialer.Open(guestModel.contactno);
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
        public async void OnMessageCommand(Parents guestModel)
        {
            try
            {
                var message = new SmsMessage("You Have to come to collect refund money", guestModel.contactno);
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
        public async void OnWhatsappCommand(Parents guestModel)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + guestModel.contactno));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }
    }
}
