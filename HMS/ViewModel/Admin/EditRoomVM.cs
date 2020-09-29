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
    public class EditRoomVM : BaseViewModel, EditRoomI
    {
        MasterServices web;
        UpdateRoomModel updateRoomModel;
        private string id;
        private string name;
        private string hostelid;
        private string hostelroomtypeid;
        private string blockid;
        private string floorid;
        private string noOfBed;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Hostelid
        {
            get
            {
                return hostelid;
            }
            set
            {
                hostelid = value;
                OnPropertyChanged("Hostelid");
            }
        }
        public string Hostelroomtypeid
        {
            get
            {
                return hostelroomtypeid;
            }
            set
            {
                hostelroomtypeid = value;
                OnPropertyChanged("Hostelroomtypeid");
            }
        }
        public string Blockid
        {
            get
            {
                return blockid;
            }
            set
            {
                blockid = value;
                OnPropertyChanged("Blockid");
            }
        }
        public string Floorid
        {
            get
            {
                return floorid;
            }
            set
            {
                floorid = value;
                OnPropertyChanged("Floorid");
            }
        }
        public string NoOfBed
        {
            get
            {
                return noOfBed;
            }
            set
            {
                noOfBed = value;
                OnPropertyChanged("NoOfBed");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ICommand UpdateRoomCommand => new Command(OnUpdateRoomCommand);
        public EditRoomVM(string id, string name, string hostelid, string hostelroomtypeid, string blockid, string floorid, string noOfBed)
        {
            Id = id;
            Name = name;
            Hostelid = hostelid;
            Hostelroomtypeid = hostelroomtypeid;
            Blockid = blockid;
            Floorid = floorid;
            NoOfBed = noOfBed;
            web = new MasterServices((EditRoomI)this);
        }
        public async void OnUpdateRoomCommand()
        {
            if(isvalidate())
            {
                updateRoomModel = new UpdateRoomModel();
                updateRoomModel.userId =App.userid;
                updateRoomModel.roomId = Id;
                updateRoomModel.roomName = Name;
                updateRoomModel.hostelId = Hostelid;
                updateRoomModel.hostelRoomTypeId = Hostelroomtypeid;
                updateRoomModel.hostelBlockId = Blockid;
                updateRoomModel.floorId = Floorid;
                updateRoomModel.noOfBeds = NoOfBed;
                web.UpdateRoom(updateRoomModel);
            }
        }
        bool isvalidate()
        {
            if(String.IsNullOrEmpty(Name)|| Name.Length==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Name Required", "OK");
                return false;
            }
            else if(String.IsNullOrEmpty(NoOfBed)|| NoOfBed.Length==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "No of Beds Required", "OK");
                return false;

            }
            return true;
        }
        public async void EditRoomSucess(string resultHostel)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            App.blockid = string.Empty;
            App.hostelid = string.Empty;
            App.floorid = string.Empty;
            Id = "";
            Name = "";
            NoOfBed = "";
            Floorid = "";
            Hostelid = "";
            Blockid = "";
            Hostelroomtypeid = "";
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
