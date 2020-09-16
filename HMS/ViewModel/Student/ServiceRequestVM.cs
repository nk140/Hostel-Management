using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class ServiceRequestVM : BaseViewModel, Iservicecategory
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
        #endregion
        #region commands
        public ICommand SaveRequestCommand => new Command(OnSaveRequestCommand);
        #endregion
        public ServiceRequestVM()
        {
            studentService = new StudentService(this);
            studentService.GetServiceType();
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
    }
}
