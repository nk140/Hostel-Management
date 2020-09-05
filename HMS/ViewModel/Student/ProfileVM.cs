using Xamarin.Essentials;

namespace HMS.ViewModel.Student
{
    public class ProfileVM : BaseViewModel
    {
        private string studentname;
        private string phoneno;
        private string email;
        private string hostelName;
        private string floorNo;
        private string roomno;
        private string bedno;
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
        public ProfileVM()
        {
            StudentName = SecureStorage.GetAsync("studentName").GetAwaiter().GetResult();
            Phoneno = "9977556645";
            Email = SecureStorage.GetAsync("email").GetAwaiter().GetResult();
            HostelName = "Dream Hostel";
            FloorNo = "13";
            Roomno = "34";
            BedNo = "3";
        }
    }
}
