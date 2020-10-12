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
        private WardenServiceModel _OldDisciplinaryData;
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
        public ICommand TapCommand => new Command<WardenServiceModel>(OnTapCommand);
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
        public async void OnTapCommand(WardenServiceModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(WardenServiceModel obj)
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
                    foreach (var items in WardenServiceData)
                    {
                        if (_OldDisciplinaryData.name == items.name)
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
        public void UpdateProduct(WardenServiceModel obj)
        {
            var index = WardenServiceData.IndexOf(obj);
            WardenServiceData.Remove(obj);
            WardenServiceData.Insert(index, obj);
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

        public async void Servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            WardenServiceData.Clear();
            OnPropertyChanged("WardenServiceData");
        }
    }
}
