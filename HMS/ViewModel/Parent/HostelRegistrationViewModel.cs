using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Parent
{
    public class HostelRegistrationViewModel : BaseViewModel
    {
        private string userId;
        private string id;
        private string firstName;
        private string dateOfBirth;
        private string dateOfJoining;
        private string permanent_address_line_1;
        private string permanent_address_line_2;
        private string permanent_address_city;
        private string email;
        private string mobile_no;
        private string blood_group;
        private string username;
        /*private string gender;
        private string isParent;
        private string parentId;
        private string studentId;
        private string userType;*/
        #region properites
        public string Userid
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged();
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Firstname
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string Dateofbirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        public string Dateofjoin
        {
            get
            {
                return dateOfJoining;
            }
            set
            {
                dateOfJoining = value;
                OnPropertyChanged();
            }
        }
        public string PAddress1
        {
            get
            {
                return permanent_address_line_1;
            }
            set
            {
                permanent_address_line_1 = value;
                OnPropertyChanged();
            }
        }
        public string PAddress2
        {
            get
            {
                return permanent_address_line_2;
            }
            set
            {
                permanent_address_line_2 = value;
                OnPropertyChanged();
            }
        }
        public string PAddresscity
        {
            get
            {
                return permanent_address_city;
            }
            set
            {
                permanent_address_city = value;
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
        public string Mobile
        {
            get
            {
                return mobile_no;
            }
            set
            {
                mobile_no = value;
                OnPropertyChanged();
            }
        }
        public string Blood
        {
            get
            {
                return blood_group;
            }
            set
            {
                blood_group = value;
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
        #endregion
        #region Commands
        public ICommand UpdateWardenInfoCommand => new Command(OnUpdateWardenInfoCommand);
        #endregion
        public async void OnUpdateWardenInfoCommand()
        {

        }

        public HostelRegistrationViewModel()
        {
            Firstname = SecureStorage.GetAsync("firstName").GetAwaiter().GetResult();
            var add1 = SecureStorage.GetAsync("permanent_address_line_1").GetAwaiter().GetResult();
            var add2 = SecureStorage.GetAsync("permanent_address_line_2").GetAwaiter().GetResult();
            var result = add1 + add2;
            PAddress1 = result;
            PAddresscity = SecureStorage.GetAsync("permanent_address_city").GetAwaiter().GetResult();
            Mobile = SecureStorage.GetAsync("mobile_no").GetAwaiter().GetResult();
            Email = SecureStorage.GetAsync("email").GetAwaiter().GetResult();
            Blood = SecureStorage.GetAsync("blood_group").GetAwaiter().GetResult();
            Username = "raj";

        }
    }
}



