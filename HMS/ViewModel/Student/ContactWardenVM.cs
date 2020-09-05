using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.ViewModel.Student
{
    public class ContactWardenVM : BaseViewModel, ContactWardenI
    {
        public ContactWardenVM()
        {
            web = new StudentService(this);
            web.GetAllWarden();
        }

        StudentService web;

        private ObservableCollection<WardenInfoModel> warden_ = new ObservableCollection<WardenInfoModel>();


        public ObservableCollection<WardenInfoModel> Warden
        {
            get { return warden_; }
            set { warden_ = value; OnPropertyChanged("Warden"); }
        }

        public async Task ServiceFaild()
        {

        }

        public async Task GetAllWarden(ObservableCollection<WardenInfoModel> warden__)
        {
            Warden = new ObservableCollection<WardenInfoModel>();
            Warden = warden__;
            OnPropertyChanged("Warden");
        }
    }
}
