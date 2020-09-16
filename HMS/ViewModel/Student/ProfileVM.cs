using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class ProfileVM : BaseViewModel, ProfileI
    {
        private string studentname;
        private string phoneno;
        private string email;
        private string hostelName;
        private string floorNo;
        private string roomno;
        private string bedno;
        public ProfileUpdate profileUpdate;
        public StudentService studentService;
        #region properties
        public string StudentName
        {
            get
            {
                return studentname;
            }
            set
            {
                studentname = value;
                OnPropertyChanged();
            }
        }
        public string Phoneno
        {
            get
            {
                return phoneno;
            }
            set
            {
                phoneno = value;
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
        public string HostelName
        {
            get
            {
                return hostelName;
            }
            set
            {
                hostelName = value;
                OnPropertyChanged();
            }
        }
        public string FloorNo
        {
            get
            {
                return floorNo;
            }
            set
            {
                floorNo = value;
                OnPropertyChanged();
            }
        }
        public string Roomno
        {
            get
            {
                return roomno;
            }
            set
            {
                roomno = value;
                OnPropertyChanged();
            }
        }
        public string BedNo
        {
            get
            {
                return bedno;
            }
            set
            {
                bedno = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand UpdateCommand => new Command(OnUpdateCommand);

        #endregion
        public ProfileVM()
        {
            StudentName = SecureStorage.GetAsync("studentName").GetAwaiter().GetResult();
            if (string.IsNullOrEmpty(App.studentupdatedphoneno) || App.studentupdatedphoneno.Length == 0)
                Phoneno = SecureStorage.GetAsync("mobileNo").GetAwaiter().GetResult();
            else
                Phoneno = App.studentupdatedphoneno;
            Email = SecureStorage.GetAsync("email").GetAwaiter().GetResult();
            HostelName = "Dream Hostel";
            FloorNo = "13";
            Roomno = "34";
            BedNo = "3";
            studentService = new StudentService(this);
        }
        public async void OnUpdateCommand()
        {
            if (string.IsNullOrEmpty(Phoneno))
                await App.Current.MainPage.DisplayAlert("HMS", "Please enter mobile no.", "OK");
            else if (Phoneno.Length != 10)
                await App.Current.MainPage.DisplayAlert("HMS", "Please enter 10 digit mobile no.", "OK");
            else
            {
                profileUpdate = new ProfileUpdate();
                profileUpdate.studentId = App.userid;
                profileUpdate.stuPhoneNo = Phoneno;
                studentService.UpdateProfile(profileUpdate);
            }
        }

        public void LoadStudentProfile(StudentProfileModel profiles)
        {
            throw new System.NotImplementedException();
        }

        public Task ServiceFaild()
        {
            throw new System.NotImplementedException();
        }

        public async void UpdatedSucessfully(string result)
        {
            phoneno = string.Empty;
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged();
        }
    }
}
