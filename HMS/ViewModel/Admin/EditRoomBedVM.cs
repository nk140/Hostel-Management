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
    public class EditRoomBedVM : BaseViewModel, EditRoomBedI
    {
        MasterServices web;
        private UpdateRoomBed updateRoomBed = new UpdateRoomBed();
        public UpdateRoomBed UpdateRoomBed
        {
            get
            {
                return updateRoomBed;
            }
            set
            {
                updateRoomBed = value;
                OnPropertyChanged("UpdateRoomBed");
            }
        }
        private string roomname;
        public string RommName
        {
            get
            {
                return roomname;
            }
            set
            {
                roomname = value;
                OnPropertyChanged("RommName");
            }
        }
        public ICommand UpdateRoomBedCommand => new Command(OnUpdateRoomBedCommand);
        public EditRoomBedVM(string roomname,string bedId,string bedNo,string hostelRoomId,string hostelId)
        {
            RommName = roomname;
            updateRoomBed.bedId = bedId;
            updateRoomBed.bedNo = bedNo;
            updateRoomBed.hostelRoomId = hostelRoomId;
            updateRoomBed.hostelId = hostelId;
            web = new MasterServices((EditRoomBedI)this);
        }
        public async void OnUpdateRoomBedCommand()
        {
            if (string.IsNullOrEmpty(updateRoomBed.bedNo) || updateRoomBed.bedNo.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Bed Name Required", "OK");
            else
            {
                updateRoomBed.userId = App.userid;
                web.UpdateRoomBed(updateRoomBed);
            }
        }

        public async void EditRoomBedSucess(string result)
        {
            updateRoomBed = new UpdateRoomBed();
            RommName = "";
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("updateRoomBed");
            OnPropertyChanged("RommName");
        }

        public async void Failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
