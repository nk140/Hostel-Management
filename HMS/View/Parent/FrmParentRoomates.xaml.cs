
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parrent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmParentRoomates : ContentPage
    {
        public FrmParentRoomates()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var phoneno = "9078802809";
            try
            {
                PhoneDialer.Open(phoneno);
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

        private async void TapGestureRecognizer_Tapped_1(object sender, System.EventArgs e)
        {
            var phoneno2 = "9234948909";
            try
            {
                var message = new SmsMessage("", phoneno2);
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

        private async void TapGestureRecognizer_Tapped_2(object sender, System.EventArgs e)
        {
            var phone3 = "8286452131";
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + phone3));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            var phoneno2 = "9234948909";
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + phoneno2));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            var phoneno2 = "9234948909";
            try
            {
                PhoneDialer.Open(phoneno2);
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

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            var phoneno = "9078802809";
            try
            {
                var message = new SmsMessage("", phoneno);
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

        private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            var phoneno = "9078802809";
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + phoneno));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            var phone3 = "8286452131";
            try
            {
                PhoneDialer.Open(phone3);
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

        private async void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            var phone3 = "8286452131";
            try
            {
                var message = new SmsMessage("", phone3);
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
    }
}