using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.ViewModel.Student
{
    public class ContactWardenVM : BaseViewModel, ProfileI
    {
        public ContactWardenVM()
        {
            web = new StudentService(this);
            web.GetProfiile(App.userid);
        }

        StudentService web;

        private ObservableCollection<StudentProfileModel> warden_ = new ObservableCollection<StudentProfileModel>();


        public ObservableCollection<StudentProfileModel> Warden
        {
            get { return warden_; }
            set { warden_ = value; OnPropertyChanged("Warden"); }
        }

        public async Task ServiceFaild()
        {

        }

        public async Task GetAllWarden(ObservableCollection<WardenInfoModel> warden__)
        {
           // Warden = new ObservableCollection<WardenInfoModel>();
           // Warden = warden__;
           // OnPropertyChanged("Warden");
        }

        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            Warden = profiles;
            OnPropertyChanged("Warden");
        }

        public void UpdatedSucessfully(string result)
        {
            throw new System.NotImplementedException();
        }
    }
}
