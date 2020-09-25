using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class ServiceCategory : BaseViewModel, Iservicewarden,IDeleteservicecategory
    {
        WardenService warden;
        MasterServices web;
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
        public ICommand EditCommand => new Command<WardenServiceModel>(OnEditCommand);
        public ICommand DeleteCommand => new Command<WardenServiceModel>(OnDeleteCommand);
        public ServiceCategory()
        {
            warden = new WardenService(this);
            web = new MasterServices((IDeleteservicecategory)this);
            warden.GetServicelist();
        }
        public async void OnEditCommand(WardenServiceModel obj)
        {

            await App.Current.MainPage.Navigation.PushModalAsync(new EditServiceCategory(obj.id.ToString(), obj.name,App.userid));
        }
        public async void OnDeleteCommand(WardenServiceModel obj)
        {
            web.DeleteServiceCategory(obj.id.ToString());
        }
        public void GetServicelist(ObservableCollection<WardenServiceModel> servicelists)
        {
            WardenServiceData = new ObservableCollection<WardenServiceModel>();
            WardenServiceData = servicelists;
            OnPropertyChanged();
        }

        public async void Deleteservicecategory(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            warden.GetServicelist();
        }

        public async void failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
