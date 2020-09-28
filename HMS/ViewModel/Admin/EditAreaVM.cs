using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class EditAreaVM : BaseViewModel, CountryI, EditAreaI
    {
        private CountryModel CountryList = new CountryModel();
        private UpdateAreModel updateAre;
        private ObservableCollection<StateModel> stateModel_ = new ObservableCollection<StateModel>();
        private ObservableCollection<CountryModel> countryListmodels_ = new ObservableCollection<CountryModel>();
        private string countryname;
        private string statename;
        private AreaModel areasAvailableTo_ = new AreaModel();
        MasterServices web;
        public ObservableCollection<CountryModel> CountryModel
        {
            get { return countryListmodels_; }
            set { countryListmodels_ = value; OnPropertyChanged("CountryModel"); }
        }
        public string Contryname
        {
            get
            {
                return countryname;
            }
            set
            {
                countryname = value;
                OnPropertyChanged("Contryname");
            }
        }
        public string Statename
        {
            get
            {
                return statename;
            }
            set
            {
                statename = value;
                OnPropertyChanged("Statename");
            }
        }
        public UpdateAreModel UpdateAreModel
        {
            get
            {
                return updateAre;
            }
            set
            {
                updateAre = value;
                OnPropertyChanged("UpdateAreModel");
            }
        }
        public ObservableCollection<StateModel> StateModel
        {
            get { return stateModel_; }
            set { stateModel_ = value; OnPropertyChanged("StateModel"); }
        }
        public AreaModel Area
        {
            get { return areasAvailableTo_; }
            set { areasAvailableTo_ = value; OnPropertyChanged("Area"); }
        }
        public ICommand UpdateCommand => new Command(OnUpdateCommand);
        public EditAreaVM(string areaid,string areaname,string stateid)
        {
            updateAre = new UpdateAreModel();
            Area.id = areaid;
            Area.areaName = areaname;
            Area.stateId = stateid;
            web = new MasterServices((CountryI)this, (EditAreaI)this);
            web.StateListForEditing(stateid);
            CountryList = new CountryModel();
            web.GetCountryDetails();
        }
        public async void OnUpdateCommand()
        {
            try
            {
                if (validate())
                {
                    updateAre.userId = App.userid;
                    updateAre.areaId = Area.id;
                    updateAre.areaName = Area.areaName;
                    updateAre.stateId = Area.stateId;
                    web.UpdateArea(updateAre);
                }
            }
            catch (Exception ex)
            {

            }
        }
        bool validate()
        {
            if (string.IsNullOrEmpty(Area.areaName) || Area.areaName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Area Name", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(Area.stateId) || Area.stateId.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter State", "OK");
                return false;
            }
            return true;
        }
        public void Statelist(string id)
        {
           // web.StateListForEditing(id);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> areaList)
        {

        }

        public async Task LoadAreaListFail()
        {

        }

        public async Task LoadCountry(ObservableCollection<CountryModel> countryList)
        {
            CountryModel = countryList;
            OnPropertyChanged();
        }

        public async Task LoadCountryFail()
        {

        }

        public async Task LoadStateList(ObservableCollection<StateModel> stateList)
        {
            StateModel = stateList;
            Statename = StateModel[0].state;
            OnPropertyChanged("Statename");
            OnPropertyChanged("StateModel");
        }

        public async Task LoadStateListFail()
        {

        }

        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void UpdateAreaDetailSucess(string result)
        {
            updateAre = new UpdateAreModel();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
