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

namespace HMS.ViewModel.Warden
{
    public class ContactDirectorVM : BaseViewModel,IViewDirectorDetail
    {
        WardenService wardenService;
        private ObservableCollection<ViewDirectorDetails> viewDirectorDetails = new ObservableCollection<ViewDirectorDetails>();
        public ObservableCollection<ViewDirectorDetails> ViewDirectorDetails
        {
            get
            {
                return viewDirectorDetails;
            }
            set
            {
                viewDirectorDetails = value;
                OnPropertyChanged("ViewDirectorDetails");
            }
        }
        public ICommand WhatsappCommand => new Command<ViewDirectorDetails>(OnWhatsappCommand);
        public ICommand MessageCommand => new Command<ViewDirectorDetails>(OnMessageCommand);
        public ICommand CallCommand => new Command<ViewDirectorDetails>(OnCallCommand);
        public ContactDirectorVM()
        {
            wardenService = new WardenService((IViewDirectorDetail)this);
        }
        public void GetDirectorDetails(ObservableCollection<ViewDirectorDetails> viewDirectorDetails)
        {
            ViewDirectorDetails = viewDirectorDetails;
            OnPropertyChanged("ViewDirectorDetails");
        }
        public async void OnWhatsappCommand(ViewDirectorDetails studetns)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + studetns.contact));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }
        public async void OnMessageCommand(ViewDirectorDetails students)
        {
            try
            {
                var message = new SmsMessage("", students.contact);
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
        public async void OnCallCommand(ViewDirectorDetails students)
        {
            try
            {
                PhoneDialer.Open(students.contact);
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
        public async void failer(string result)
        {
            ViewDirectorDetails.Clear();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("ViewDirectorDetails");
        }
    }
}
