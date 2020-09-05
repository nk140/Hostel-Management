using HMS.Data;
using HMS.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class GuestContactList : BaseViewModel
    {
        GuestList guestList = new GuestList();
        #region guestlistproperties
        private ObservableCollection<GuestModel> ListOfGuests = new ObservableCollection<GuestModel>();
        public ObservableCollection<GuestModel> listofguests
        {
            get
            {
                return ListOfGuests;
            }
            set
            {
                ListOfGuests = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Tapcommands
        public ICommand CallCommand => new Command<GuestModel>(OnCallCommand);
        public ICommand MessageCommand => new Command<GuestModel>(OnMessageCommand);
        public ICommand WhatsappCommand => new Command<GuestModel>(OnWhatsappCommand);
        #endregion
        public GuestContactList()
        {
            listofguests = new ObservableCollection<GuestModel>(guestList.Guests);
        }
        public async void OnCallCommand(GuestModel guestModel)
        {
            try
            {
                PhoneDialer.Open(guestModel.Contactno);
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
        public async void OnMessageCommand(GuestModel guestModel)
        {
            try
            {
                var message = new SmsMessage("You Have to come to collect refund money", guestModel.Contactno);
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
        public async void OnWhatsappCommand(GuestModel guestModel)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + guestModel.Contactno));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }
    }
}
