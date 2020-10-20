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

namespace HMS.ViewModel.Student
{
    public class ServiceRequestVM : BaseViewModel, Iservicecategory,ProfileI
    {
        private ObservableCollection<WardenServiceModel> wardenServiceModels = new ObservableCollection<WardenServiceModel>();
        StudentService studentService;
        private string servicecategoryname;
        private string servicedescription;
        #region Listproperties
        public ObservableCollection<WardenServiceModel> WardenServiceModels
        {
            get
            {
                return wardenServiceModels;
            }
            set
            {
                wardenServiceModels = value;
                OnPropertyChanged();
            }
        }
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
        private RequestServiceModel requestService = new RequestServiceModel();
        public RequestServiceModel RequestServiceModel
        {
            get
            {
                return requestService;
            }
            set
            {
                requestService = value;
                OnPropertyChanged("RequestServiceModel");
            }
        }
        #endregion
        #region properties
        public string Servicecategoryname
        {
            get
            {
                return servicecategoryname;
            }
            set
            {
                servicecategoryname = value;
                OnPropertyChanged();
            }
        }
        public string Servicedescription
        {
            get
            {
                return servicedescription;
            }
            set
            {
                servicedescription = value;
                OnPropertyChanged();
            }
        }
        private string roomname;
        public string Roomname
        {
            get
            {
                return roomname;
            }
            set
            {
                roomname = value;
                OnPropertyChanged("Roomname");
            }
        }
        #endregion
        #region commands
        public ICommand SaveRequestCommand => new Command(OnSaveRequestCommand);
        #endregion
        public ServiceRequestVM()
        {
            studentService = new StudentService((Iservicecategory)this,(ProfileI)this);
            studentService.GetServiceType();
            studentService.GetProfiile(App.userid);
        }
        public async void OnSaveRequestCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Servicecategoryname) || Servicecategoryname.Length == 0)
                    await App.Current.MainPage.DisplayAlert("HMS", "Enter Service Category", "OK");
                else if (string.IsNullOrEmpty(Servicedescription) || Servicedescription.Length == 0)
                    await App.Current.MainPage.DisplayAlert("HMS", "Enter Description", "OK");
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        public void getallservicecategory(ObservableCollection<WardenServiceModel> wardenServiceModels)
        {
            WardenServiceModels = new ObservableCollection<WardenServiceModel>();
            WardenServiceModels = wardenServiceModels;
            OnPropertyChanged();
        }
        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            StudentProfileModel = profiles;
            Roomname = StudentProfileModel[0].roomName;
            OnPropertyChanged("StudentProfileModel");
            OnPropertyChanged("Roomname");
        }

        public async Task ServiceFaild()
        {
            
        }

        public void UpdatedSucessfully(string result)
        {
            
        }

        public void requestedsucess(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void failer(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void Loadwardenprofile(ObservableCollection<WardenProfileModel> wardenProfileModels)
        {
            throw new NotImplementedException();
        }
    }
}
