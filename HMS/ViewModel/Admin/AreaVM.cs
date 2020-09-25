using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class AreaVM : BaseViewModel, CountryI, AreaI
    {
        public AreaVM()
        {
            CountryVisible = false;
            StateVisible = false;
            AreaVisible = false;
            CountryList = new CountryModel();
            web = new MasterServices((CountryI)this, (AreaI)this);
            // send id into base 64 formate
            web.GetCountryDetails();
        }
        #region DeclareVariableAndObj

        private CountryModel CountryList = new CountryModel();
        private ObservableCollection<StateModel> stateModel_ = new ObservableCollection<StateModel>();
        private ObservableCollection<CountryModel> countryListmodels_ = new ObservableCollection<CountryModel>();
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private bool countryVisible;
        private bool stateVisible;
        private bool areaVisible;
        private long countryHeight;
        private long stateHeight;
        private long areaHeight;
        private string CountryName_;
        private string StateName_;
        private string AreaName_;
        private AreaModel areasAvailableTo_ = new AreaModel();
        MasterServices web;
        #endregion

        #region AssignVariableAndObj
        #region VariableAssign

        public string CountryName
        {
            get { return CountryName_; }
            set { CountryName_ = value; OnPropertyChanged("CountryName"); }
        }
        public string StateName
        {
            get { return StateName_; }
            set { StateName_ = value; OnPropertyChanged("StateName"); }
        }

        public string AreaName
        {
            get { return AreaName_; }
            set { AreaName_ = value; OnPropertyChanged("AreaName"); }
        }
        public bool CountryVisible
        {
            get { return countryVisible; }
            set { countryVisible = value; OnPropertyChanged(); }
        }
        public bool StateVisible
        {
            get { return stateVisible; }
            set { stateVisible = value; OnPropertyChanged(); }
        }
        public bool AreaVisible
        {
            get { return areaVisible; }
            set { areaVisible = value; OnPropertyChanged(); }
        }
        public long CountryHeight
        {
            get { return countryHeight; }
            set { countryHeight = value; OnPropertyChanged(); }
        }
        public long StateHeight
        {
            get { return stateHeight; }
            set { stateHeight = value; OnPropertyChanged(); }
        }
        public long AreaHeight
        {
            get { return areaHeight; }
            set { areaHeight = value; OnPropertyChanged(); }
        }
        #endregion

        #region AssignModelClass

        public AreaModel Area
        {
            get { return areasAvailableTo_; }
            set { areasAvailableTo_ = value; OnPropertyChanged("Area"); }

        }

        public ObservableCollection<CountryModel> CountryModel
        {
            get { return countryListmodels_; }
            set { countryListmodels_ = value; OnPropertyChanged("CountryModel"); }
        }
        public ObservableCollection<StateModel> StateModel
        {
            get { return stateModel_; }
            set { stateModel_ = value; OnPropertyChanged("StateModel"); }
        }
        public ObservableCollection<AreaModel> AreaModel
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("StateModel"); }
        }

        #endregion
        #endregion


        #region Commands

        public Command SetCountryVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (CountryModel != null)
                    {
                        if (CountryModel.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Country", "OK");
                            CountryVisible = false;
                        }
                        else
                        {
                            CountryHeight = (40 * CountryModel.Count) + 20;
                            CountryVisible = !CountryVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Country", "OK");
                        CountryVisible = false;
                    }


                    OnPropertyChanged("CountryModelList");
                });
            }
        }
        public Command SetStateVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (StateModel != null)
                    {
                        if (StateModel.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no State", "OK");
                            StateVisible = false;
                        }
                        else
                        {
                            StateHeight = (40 * StateModel.Count) + 20;
                            StateVisible = !StateVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no State", "OK");
                        StateVisible = false;
                    }


                    OnPropertyChanged("StateModelList");
                });
            }
        }
        public Command SetAreaVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (AreaModel != null)
                    {
                        if (AreaModel.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Area", "OK");
                            AreaVisible = false;
                        }
                        else
                        {
                            AreaHeight = (40 * AreaModel.Count) + 20;
                            AreaVisible = !AreaVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Area", "OK");
                        AreaVisible = false;
                    }


                    OnPropertyChanged("AreaModelList");
                });
            }
        }
        public Command CountrySelected
        {
            get
            {
                return new Command(() => { CountrySelection(); });
            }
        }
        public void CountrySelection()
        {

        }
        public Command StateSelected
        {
            get
            {
                return new Command(() => { StateSelection(); });
            }
        }

        public void StateSelection()
        {

        }
        public Command AreaSelected
        {
            get
            {
                return new Command(() => { AreaSelection(); });
            }
        }

        public void AreaSelection()
        {

        }

        public Command SaveCommand
        {
            get
            {
                return new Command(() => { SaveAsync(); });
            }
        }
        public void SaveAsync()
        {
            Area.areaName = AreaName;
            //Area.id = App.userid;
            if (Area.stateId == null || Area.stateId.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select State", "OK");
            }
            else if (Area.areaName == null || Area.areaName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Enter Area Name", "OK");
            }
            else
            {
                SaveAreaModel saveAreaModel = new SaveAreaModel();
                saveAreaModel.userId = App.userid;
                saveAreaModel.stateId = Area.stateId;
                saveAreaModel.areaName = Area.areaName;
                web.SaveAreaEntry(saveAreaModel);
                // new CountryReportService((AreaEntryI)this).SaveAreaEntry(Area);
            }

        }
        #endregion


        public void CountrySelection(int index)
        {
            CountryVisible = !CountryVisible;//true

            // display entry selected text value
            CountryName = CountryModel[index].country;
            OnPropertyChanged("CountryName");
            Area = new AreaModel();
            //selected value defined by index then move to next url to display
            web.RequestStateList(CountryModel[index]);

        }
        public void StateSelection(int index)
        {
            StateVisible = !StateVisible;//true

            // display entry selected text value
            StateName = StateModel[index].state;
            OnPropertyChanged("StateName");
            Area.stateId = StateModel[index].id;
            //selected value defined by index then move to next url to display
            web.RequestAreaList(StateModel[index]);

        }
        public void AreaSelection(int index)
        {
            AreaVisible = !AreaVisible;//true

            // display entry selected text value
            AreaName = AreaModel[index].areaName;
            OnPropertyChanged("AreaName");

            //selected value defined by index then move to next url to display
            // web.RequestStateList(StateModel[index]);

        }

        public async Task LoadAreaList(ObservableCollection<AreaModel> areaList)
        {
            AreaModel = new ObservableCollection<AreaModel>();
            AreaModel = areaList;
            OnPropertyChanged("AreaModel");
        }

        public async Task LoadAreaListFail()
        {

        }

        public async Task LoadCountry(ObservableCollection<CountryModel> countryList)
        {
            CountryModel = new ObservableCollection<CountryModel>();
            CountryModel = countryList;
            OnPropertyChanged("CountryModel");
        }

        public async Task LoadCountryFail()
        {

        }

        public async Task LoadStateList(ObservableCollection<StateModel> stateList)
        {
            StateModel = new ObservableCollection<StateModel>();
            StateModel = stateList;
            OnPropertyChanged("StateModel");
        }

        public async Task LoadStateListFail()
        {

        }

        public async Task PostAreaNameSuccess(string result)
        {
            CountryName = string.Empty;
            StateName = string.Empty;
            AreaName = string.Empty;
            await App.Current.MainPage.DisplayAlert("", result, "OK");
        }

        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("", result, "OK");
        }
    }
}
