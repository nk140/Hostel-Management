using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class EditFacilityVM : BaseViewModel, EditFasilityI
    {
        MasterServices web;
        private UpdateFacility updateFacility = new UpdateFacility();
        public UpdateFacility UpdateFacility
        {
            get
            {
                return updateFacility;
            }
            set
            {
                updateFacility = value;
                OnPropertyChanged("UpdateFacility");
            }
        }
        public ICommand UpdateCommand => new Command(OnUpdateCommand);
        public EditFacilityVM(string id,string facility,string userid)
        {
            UpdateFacility.id = id;
            UpdateFacility.name = facility;
            UpdateFacility.userId = userid;
            web = new MasterServices((EditFasilityI)this);
        }
        public async void OnUpdateCommand()
        {
            if (UpdateFacility.name.Length == 0 || string.IsNullOrEmpty(UpdateFacility.name))
                await App.Current.MainPage.DisplayAlert("HMS", "Facility Name Required", "OK");
            else
                web.UpdateFacility(UpdateFacility);
        }
        public async void PostFasilitySuccess(string resultHostel)
        {
            UpdateFacility = new UpdateFacility();
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            OnPropertyChanged("UpdateFacility");
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
