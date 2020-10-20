using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.ViewModel.Warden
{
    public class HostelDetailMasterViewModel : BaseViewModel,ProfileI
    {
        WardenService warden;
        private ObservableCollection<WardenProfileModel> HostelData = new ObservableCollection<WardenProfileModel>();
        #region list
        public ObservableCollection<WardenProfileModel> HostalMasterData
        {
            get
            {
                return HostelData;
            }
            set
            {
                HostelData = value;
                OnPropertyChanged("HostelData");
            }
        }
        private bool isdataavailable;
        public bool Isdataavailable
        {
            get
            {
                return isdataavailable;
            }
            set
            {
                isdataavailable = value;
                OnPropertyChanged("Isdataavailable");
            }
        }
        #endregion
        public HostelDetailMasterViewModel()
        {
            warden = new WardenService(this);
            warden.GetWardenprofile(App.userid);
        }
        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            throw new System.NotImplementedException();
        }

        public void Loadwardenprofile(ObservableCollection<WardenProfileModel> wardenProfileModels)
        {
            Isdataavailable = true;
            HostalMasterData = wardenProfileModels;
            OnPropertyChanged("HostalMasterData");
        }

        public async Task ServiceFaild()
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No data found", "OK");
        }

        public void UpdatedSucessfully(string result)
        {
            throw new System.NotImplementedException();
        }
    }
}
