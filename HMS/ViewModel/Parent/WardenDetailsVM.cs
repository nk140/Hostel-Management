using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Parent
{
    public class WardenDetailsVM : BaseViewModel,ProfileI
    {
        private ObservableCollection<StudentProfileModel> wardenInfoModels = new ObservableCollection<StudentProfileModel>();
        public StudentService studentService;
        #region listproperties
        public ObservableCollection<StudentProfileModel> WardenInfoModels
        {
            get
            {
                return wardenInfoModels;
            }
            set
            {
                wardenInfoModels = value;
                OnPropertyChanged("WardenInfoModels");
            }
        }
        #endregion
        #region Tapcommands
        public ICommand CallCommand => new Command<StudentProfileModel>(OnCallCommand);
        public ICommand MessageCommand => new Command<StudentProfileModel>(OnMessageCommand);

        [Obsolete]
        public ICommand WhatsappCommand => new Command<StudentProfileModel>(OnWhatsappCommand);
        #endregion
        public WardenDetailsVM()
        {
            studentService = new StudentService(this);
            string childid = SecureStorage.GetAsync("studentId").GetAwaiter().GetResult();
            studentService.GetProfiile(childid);
        }
        public async void OnCallCommand(StudentProfileModel guestModel)
        {
            try
            {
                PhoneDialer.Open(guestModel.wardenPhoneNo);
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
        public async void OnMessageCommand(StudentProfileModel guestModel)
        {
            try
            {
                var message = new SmsMessage("", guestModel.wardenPhoneNo);
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
        public async void OnWhatsappCommand(StudentProfileModel guestModel)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + guestModel.wardenPhoneNo));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }

        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            WardenInfoModels = profiles;
            OnPropertyChanged("WardenInfoModels");
        }

        public void Loadwardenprofile(ObservableCollection<WardenProfileModel> wardenProfileModels)
        {
            
        }

        public async Task ServiceFaild()
        {
           
        }

        public void UpdatedSucessfully(string result)
        {
            throw new NotImplementedException();
        }
    }
}
