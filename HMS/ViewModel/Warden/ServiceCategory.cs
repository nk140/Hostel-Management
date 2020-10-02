using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;

namespace HMS.ViewModel.Warden
{
    public class ServiceCategory : BaseViewModel, Iservicewarden
    {
        WardenService warden;
        private ObservableCollection<WardenServiceModel> servicelists = new ObservableCollection<WardenServiceModel>();
        #region list
        public ObservableCollection<WardenServiceModel> WardenServiceData
        {
            get
            {
                return servicelists;
            }
            set
            {
                servicelists = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public ServiceCategory()
        {
            warden = new WardenService(this);
            warden.GetServicelist();
        }
        public void GetServicelist(ObservableCollection<WardenServiceModel> servicelists)
        {
            WardenServiceData = new ObservableCollection<WardenServiceModel>();
            WardenServiceData = servicelists;
            OnPropertyChanged();
        }

        public async void Servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            WardenServiceData.Clear();
            OnPropertyChanged("WardenServiceData");
        }
    }
}
