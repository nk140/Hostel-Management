using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
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
        private ObservableCollection<StudentProfileModel> studentProfile = new ObservableCollection<StudentProfileModel>();
        public ObservableCollection<StudentProfileModel> StudentProfileModel
        {
            get
            {
                return studentProfile;
            }
            set
            {
                studentProfile = value;
                OnPropertyChanged("StudentProfileModel");
            }
        }
        public ProfileVM()
        {
            studentService = new StudentService(this);
            studentService.GetProfiile(App.userid);
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

        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            StudentProfileModel = profiles;
            foreach (var items in StudentProfileModel)
            {
                StudentName = items.studentName;
                Phoneno = items.studentPhoneNo;
                Email = items.studentemail;
                HostelName = items.hostelName;
                FloorNo = items.floreNo;
                Roomno = items.roomName;
                BedNo = items.bedNo;
            }
            OnPropertyChanged("StudentProfileModel");
        }

        public async Task ServiceFaild()
        {
            await App.Current.MainPage.DisplayAlert("HMS", "Student doesn't exists", "OK");
        }

        public async void UpdatedSucessfully(string result)
        {
            phoneno = string.Empty;
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged();
        }

        public void Loadwardenprofile(ObservableCollection<WardenProfileModel> wardenProfileModels)
        {
            throw new System.NotImplementedException();
        }
    }
}
