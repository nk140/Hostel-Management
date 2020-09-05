using Xamarin.Essentials;

namespace HMS.ViewModel.Guest
{
    public class GuestRegistrationViewModel : BaseViewModel
    {
        private string userId;
        private string id;
        private string firstName;
        private string dateOfBirth;
        private string permanent_address_line_1;
        private string permanent_address_line_2;
        private string permanent_address_city;
        private string email;
        private string mobile_no;
        private string blood_group;
        private string gender;
        private string userType;
        private string username;
        private string fulladdress;
        private string newpassword;
        private string cnfpassword;
        #region Properties
        public string UserId
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
        public string FirstName
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
        public string DateOfBirth
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
        public string Permanent_address_line_1
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
        public string Permanent_address_line_2
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
        public string Permanent_address_city
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
        public string Mobile_no
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
        public string Blood_group
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
        public string UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
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
        public string Cnfpassword
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
        public GuestRegistrationViewModel()
        {
            FirstName = SecureStorage.GetAsync("firstName").GetAwaiter().GetResult();
            var add1 = SecureStorage.GetAsync("permanent_address_line_1").GetAwaiter().GetResult();
            var add2 = SecureStorage.GetAsync("permanent_address_line_2").GetAwaiter().GetResult();
            Fulladdress = add1 + add2;
            Permanent_address_city = SecureStorage.GetAsync("permanent_address_city").GetAwaiter().GetResult();
            Mobile_no = SecureStorage.GetAsync("mobile_no").GetAwaiter().GetResult();
            Email = SecureStorage.GetAsync("email").GetAwaiter().GetResult();
            DateOfBirth = SecureStorage.GetAsync("dateOfBirth").GetAwaiter().GetResult();
            Gender = SecureStorage.GetAsync("gender").GetAwaiter().GetResult();
            Username = "Kavitha";
        }
    }
}
