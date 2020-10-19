using HMS.Models;
using HMS.ViewModel.Student;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmContactWarden : ContentPage
    {
        public FrmContactWarden()
        {
            InitializeComponent();

            //   PlacePhoneCall("9567114626");
            //  SendSms("Hi This is from HMS", "9567114626");

        }

        ContactWardenVM Vm;

        protected override void OnAppearing()
        {
            Vm = new ContactWardenVM();
            BindingContext = Vm;
        }

        private void OnSelectedItem(object sender, ItemTappedEventArgs e)
        {

            StudentProfileModel md = (StudentProfileModel)lv_contact.SelectedItem;



            ((ListView)sender).SelectedItem = null;
        }

        private void OnCallClick(object sender, EventArgs e)
        {





            var item_ = (sender as StackLayout).BindingContext as StudentProfileModel;
            if (item_ != null)
            {
                PlacePhoneCall(item_.wardenPhoneNo);
            }



        }

        private void OnMessageClick(object sender, EventArgs e)
        {


            var item_ = (sender as StackLayout).BindingContext as StudentProfileModel;
            if (item_ != null)
            {
                SendSms("", item_.wardenPhoneNo);
            }

        }

        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
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


        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, recipient);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Failed", "Sms is not supported on this device.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed", ex.Message, "OK");
            }
        }

        public void SendWhatsp()
        {

        }

    }
}
