using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;

namespace HMS.ViewModel.Warden
{
    public class HostelDetailMasterViewModel : BaseViewModel, IHostelMaster
    {
        WardenService warden;
        private ObservableCollection<HostalMasterModel> HostelData = new ObservableCollection<HostalMasterModel>();
        #region list
        public ObservableCollection<HostalMasterModel> HostalMasterData
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
        #endregion
        public HostelDetailMasterViewModel()
        {
            warden = new WardenService(this);
            warden.GetHostelDetailList();
        }
        public void GetHostelDetailList(ObservableCollection<HostalMasterModel> HostelData)
        {
            HostalMasterData = new ObservableCollection<HostalMasterModel>();
            HostalMasterData = HostelData;
            OnPropertyChanged();
        }
    }
}
