using HMS.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class StudentContactforwarden : INotifyPropertyChanged
    {
        //StudentList student = new StudentList();
        #region Properties
        private ObservableCollection<Students> StudentList = new ObservableCollection<Students>();
        public ObservableCollection<Students> studentlist
        {
            get
            {
                return StudentList;
            }
            set
            {
                StudentList = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public ICommand WhatsappCommand => new Command<Students>(OnWhatsappCommand);
        public ICommand MessageCommand => new Command<Students>(OnMessageCommand);
        public ICommand CallCommand => new Command<Students>(OnCallCommand);
        #region TapCommands

        #endregion
        public StudentContactforwarden()
        {
            //List<Students> lst = new List<Students>();
            //foreach (var items in student.student)
            //{
            //    lst.Add(items);
            //}
            //studentlist = new ObservableCollection<Students>(lst);
        }
        public async void OnWhatsappCommand(Students studetns)
        {
            try
            {
                //Device.OpenUri(new Uri("whatsapp://send?phone=+91" + studetns.contactno));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }
        public async void OnMessageCommand(Students students)
        {
            try
            {
                // var message = new SmsMessage("You Have to come to collect refund money", students.contactno);
                //await Sms.ComposeAsync(message);
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
        public async void OnCallCommand(Students students)
        {
            try
            {
                //PhoneDialer.Open(students.contactno);
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
