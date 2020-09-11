using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Parent
{
    public class WardenDetailsVM : BaseViewModel,IWardenDetail
    {
        private ObservableCollection<WardenInfoModel> wardenInfoModels = new ObservableCollection<WardenInfoModel>();
        public ParentService parentService;
        #region listproperties
        public ObservableCollection<WardenInfoModel> WardenInfoModels
        {
            get
            {
                return wardenInfoModels;
            }
            set
            {
                wardenInfoModels = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Tapcommands
        public ICommand CallCommand => new Command<WardenInfoModel>(OnCallCommand);
        public ICommand MessageCommand => new Command<WardenInfoModel>(OnMessageCommand);

        [Obsolete]
        public ICommand WhatsappCommand => new Command<WardenInfoModel>(OnWhatsappCommand);
        #endregion
        public WardenDetailsVM()
        {
            parentService = new ParentService(this);
            parentService.GetAllWardenData();
        }
        public async void OnCallCommand(WardenInfoModel guestModel)
        {
            try
            {
                PhoneDialer.Open(guestModel.contact);
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
        public async void OnMessageCommand(WardenInfoModel guestModel)
        {
            try
            {
                var message = new SmsMessage("You Have to come to collect refund money", guestModel.contact);
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

        [Obsolete]
        public async void OnWhatsappCommand(WardenInfoModel guestModel)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + guestModel.contact));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }
        public void GetWardenData(ObservableCollection<WardenInfoModel> wardenModels)
        {
            WardenInfoModels = new ObservableCollection<WardenInfoModel>();
            WardenInfoModels = wardenModels;
            OnPropertyChanged();
        }
    }
}
