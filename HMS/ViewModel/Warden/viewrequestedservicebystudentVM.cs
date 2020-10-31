using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Warden;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    class viewrequestedservicebystudentVM : BaseViewModel, Iviewrequestedservice,ProfileI
    {
        WardenService wardenService;
        string hostelid;
        private ObservableCollection<ViewRequestedServiceModel> viewRequestedServiceModels = new ObservableCollection<ViewRequestedServiceModel>();
        public ObservableCollection<ViewRequestedServiceModel> ViewRequestedServiceModels
        {
            get
            {
                return viewRequestedServiceModels;
            }
            set
            {
                viewRequestedServiceModels = value;
                OnPropertyChanged("ViewRequestedServiceModels");
            }
        }
        private ObservableCollection<WardenProfileModel> HostelData = new ObservableCollection<WardenProfileModel>();
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
        private ViewRequestedServiceModel _OldDisciplinaryData;

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
        public ICommand ServicePersonCommand => new Command<ViewRequestedServiceModel>(OnServicePersonCommand);
        public ICommand TapCommand => new Command<ViewRequestedServiceModel>(OnTapCommand);
        public viewrequestedservicebystudentVM()
        {
            wardenService = new WardenService((Iviewrequestedservice)this,(ProfileI)this);
            wardenService.GetWardenprofile(App.userid);
        }
        public async void OnServicePersonCommand(ViewRequestedServiceModel obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new Assignpersonpopup(obj.serviceTypeName,obj.serviceTypeId), true);
        }
        public async void OnTapCommand(ViewRequestedServiceModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(ViewRequestedServiceModel obj)
        {
            if (_OldDisciplinaryData == obj)
            {
                obj.Isbuttonvisible = !obj.Isbuttonvisible;
                UpdateProduct(obj);
            }
            else
            {
                if (_OldDisciplinaryData != null)
                {
                    foreach (var items in ViewRequestedServiceModels)
                    {
                        if (_OldDisciplinaryData.hostelName == items.hostelName)
                        {
                            _OldDisciplinaryData.Isbuttonvisible = false;
                            UpdateProduct(_OldDisciplinaryData);
                            break;
                        }
                    }
                }
                obj.Isbuttonvisible = true;
                UpdateProduct(obj);
            }
            _OldDisciplinaryData = obj;
        }
        public void UpdateProduct(ViewRequestedServiceModel obj)
        {
            var index = ViewRequestedServiceModels.IndexOf(obj);
            ViewRequestedServiceModels.Remove(obj);
            ViewRequestedServiceModels.Insert(index, obj);
        }
        public async void failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void LoadAllrequestedservicelist(ObservableCollection<ViewRequestedServiceModel> viewRequestedServiceModels)
        {
            ViewRequestedServiceModels = viewRequestedServiceModels;
            OnPropertyChanged("ViewRequestedServiceModels");
        }

        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            throw new NotImplementedException();
        }

        public void Loadwardenprofile(ObservableCollection<WardenProfileModel> wardenProfileModels)
        {
            Isdataavailable = true;
            HostalMasterData = wardenProfileModels;
            hostelid = HostalMasterData[0].hostelId;
            OnPropertyChanged("HostalMasterData");
            wardenService.GetAllrequestservicebystudent(hostelid);
        }

        public async Task ServiceFaild()
        {
           
        }

        public void UpdatedSucessfully(string result)
        {
          
        }
    }
    public class ServiceStatusbypersonVM : BaseViewModel, Iviewservicestatusbyperson, ProfileI
    {
        WardenService wardenService;
        string hostelid;
        private ObservableCollection<ServiceStatusModel> serviceStatusModels = new ObservableCollection<ServiceStatusModel>();
        public ObservableCollection<ServiceStatusModel> ServiceStatusModels
        {
            get
            {
                return serviceStatusModels;
            }
            set
            {
                serviceStatusModels = value;
                OnPropertyChanged("ServiceStatusModels");
            }
        }
        private ObservableCollection<WardenProfileModel> HostelData = new ObservableCollection<WardenProfileModel>();
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
        public ServiceStatusbypersonVM()
        {
            wardenService = new WardenService((Iviewrequestedservice)this, (ProfileI)this);
            wardenService.GetWardenprofile(App.userid);
        }
        public void LoadAllservicestatus(ObservableCollection<ServiceStatusModel> serviceStatusModels)
        {
            Isdataavailable = true;
            ServiceStatusModels = serviceStatusModels;
            OnPropertyChanged("ServiceStatusModels");
        }

        public void servicefailed(string result)
        {
           
        }

        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            
        }

        public void Loadwardenprofile(ObservableCollection<WardenProfileModel> wardenProfileModels)
        {
            
            HostalMasterData = wardenProfileModels;
            hostelid = HostalMasterData[0].hostelId;
            OnPropertyChanged("HostalMasterData");
            wardenService.GetServiceStatusbyperson(hostelid);
        }

        public async Task ServiceFaild()
        {
           
        }

        public void UpdatedSucessfully(string result)
        {
            throw new NotImplementedException();
        }
    }
}
