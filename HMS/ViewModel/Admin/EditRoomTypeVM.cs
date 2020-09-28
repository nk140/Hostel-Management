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
    class EditRoomTypeVM : BaseViewModel, EditRoomTypeI
    {
        MasterServices web;
        private UpdateRoomTypeModel updateRoomTypeModel = new UpdateRoomTypeModel();
        public UpdateRoomTypeModel UpdateRoomTypeModel
        {
            get
            {
                return updateRoomTypeModel;
            }
            set
            {
                updateRoomTypeModel = value;
                OnPropertyChanged("UpdateRoomTypeModel");
            }
        }
        public ICommand UpdateCommand => new Command(OnUpdateCommand);
        public EditRoomTypeVM(string roomid, string userid, string hostelroomtypename, string hostelid)
        {
            UpdateRoomTypeModel.id = roomid;
            UpdateRoomTypeModel.userId = userid;
            UpdateRoomTypeModel.hostelRoomTypeName = hostelroomtypename;
            UpdateRoomTypeModel.hostelId = hostelid;
            web = new MasterServices((EditRoomTypeI)this);
        }
        public async void OnUpdateCommand()
        {
            if (validate())
            {
                web.UpdateRoomType(UpdateRoomTypeModel);
            }
        }
        bool validate()
        {
            if (string.IsNullOrEmpty(UpdateRoomTypeModel.hostelRoomTypeName) || UpdateRoomTypeModel.hostelRoomTypeName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Room type required", "OK");
                return false;
            }
            return true;
        }
        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void UpdateRoomTypeSuccess(string result)
        {
            UpdateRoomTypeModel = new UpdateRoomTypeModel();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdateRoomTypeModel");
        }
    }
}
