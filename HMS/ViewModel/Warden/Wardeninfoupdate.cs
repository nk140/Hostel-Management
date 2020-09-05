using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class Wardeninfoupdate : BaseViewModel, Iwardenregistrtion
    {
        private string name;
        private string fulladdress;
        private string city;
        private string mobileno;
        private string email;
        private string role;
        private string gender;
        private string aadharno;
        private string username;
        private string newpassword;
        private string cnfpassword;
        public WardenService wardenservice;
        #region properites
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Fulladdress
        {
            get
            {
                return fulladdress;
            }
            set
            {
                fulladdress = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        public string Mobileno
        {
            get
            {
                return mobileno;
            }
            set
            {
                mobileno = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
        public string Aadharno
        {
            get
            {
                return aadharno;
            }
            set
            {
                aadharno = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string Newpassword
        {
            get
            {
                return newpassword;
            }
            set
            {
                newpassword = value;
                OnPropertyChanged();
            }
        }
        public string CnfPassword
        {
            get
            {
                return cnfpassword;
            }
            set
            {
                cnfpassword = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand UpdateWardenInfoCommand => new Command(OnUpdateWardenInfoCommand);
        #endregion
        public async void OnUpdateWardenInfoCommand()
        {
            if (Newpassword == CnfPassword)
            {
                WardenRegistration warden = new WardenRegistration();
                warden.wardenName = Name;
                warden.address = Fulladdress;
                warden.phoneNo = Mobileno;
                warden.email = Email;
                warden.wardenEmail = Email;
                warden.userName = Username;
                warden.password = Newpassword;
                warden.adharNo = Aadharno;
                warden.gender = Gender;
                wardenservice.SavewardenData(warden);
            }
            else
                await App.Current.MainPage.DisplayAlert("", "Password Doesn't match", "OK");
        }
        public void wardenregistrationresponse(string result)
        {
            App.Current.MainPage.DisplayAlert("", result, "OK");
        }
        #region Constructor
        public Wardeninfoupdate()
        {
            wardenservice = new WardenService(this);
            Name = SecureStorage.GetAsync("firstName").GetAwaiter().GetResult();
            var add1 = SecureStorage.GetAsync("permanent_address_line_1").GetAwaiter().GetResult();
            var add2 = SecureStorage.GetAsync("permanent_address_line_2").GetAwaiter().GetResult();
            var result = add1 + add2;
            Fulladdress = result;
            City = SecureStorage.GetAsync("permanent_address_city").GetAwaiter().GetResult();
            Mobileno = SecureStorage.GetAsync("mobile_no").GetAwaiter().GetResult();
            Email = SecureStorage.GetAsync("email").GetAwaiter().GetResult();
            Role = SecureStorage.GetAsync("type").GetAwaiter().GetResult();
            Gender = SecureStorage.GetAsync("gender").GetAwaiter().GetResult();
            // Username = "raj";
        }
        #endregion
    }
}
