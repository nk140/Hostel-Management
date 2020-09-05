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
    public class NewAdmittedStudent : BaseViewModel, Inewstudentdata
    {
        WardenService warden;
        private ObservableCollection<Students> students = new ObservableCollection<Students>();
        #region listproperty
        public ObservableCollection<Students> GetStudents
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand CallCommand => new Command<Students>(OnCallCommand);
        public ICommand MessageCommand => new Command<Students>(OnMessageCommand);
        public ICommand WhatsappCommand => new Command<Students>(OnWhatsappCommand);
        #endregion
        public NewAdmittedStudent()
        {
            warden = new WardenService(this);
            warden.Getnewstudentdata();
        }
        public async void OnCallCommand(Students guestModel)
        {
            try
            {
                PhoneDialer.Open(guestModel.mobileNo);
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
        public async void OnMessageCommand(Students guestModel)
        {
            try
            {
                var message = new SmsMessage("", guestModel.mobileNo);
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
        public async void OnWhatsappCommand(Students guestModel)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + guestModel.mobileNo));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Whatsapp Not Installed", "ok");
            }
        }
        public void GetNewStudentData(ObservableCollection<Students> students)
        {
            GetStudents = new ObservableCollection<Students>();
            GetStudents = students;
            OnPropertyChanged();
        }
    }
}
