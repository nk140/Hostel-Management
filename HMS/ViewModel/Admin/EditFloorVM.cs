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

namespace HMS.ViewModel.Admin
{
    public class EditFloorVM : BaseViewModel, MasterI, EditFloorI
    {
        MasterServices web;
        string blockid;
        UpdateFloorData updateFloorData = new UpdateFloorData();
        private FloorData FloorModel = new FloorData();
        public FloorData FloorModelData
        {
            get
            {
                return FloorModel;
            }
            set
            {
                FloorModel = value;
                OnPropertyChanged("FloorModelData");
            }
        }
        public ICommand UpdateFloorCommand => new Command(OnUpdateFloorCommand);
        public EditFloorVM(string floorId, string floorName, string hostelId, string noOfRooms, string blocks_id)
        {
            FloorModelData.id = Convert.ToInt32(floorId);
            FloorModelData.floorNo = floorName;
            FloorModelData.hostelId = Convert.ToInt32(hostelId);
            FloorModelData.noOfRooms = Convert.ToInt32(noOfRooms);
            blockid = blocks_id;
            web = new MasterServices((MasterI)this, (EditFloorI)this);
        }
        public async void OnUpdateFloorCommand()
        {
            if(validate())
            {
                updateFloorData.floorId = FloorModelData.id.ToString();
                updateFloorData.userId = App.userid;
                updateFloorData.floorName = FloorModelData.floorNo;
                updateFloorData.hostelId = FloorModelData.hostelId.ToString();
                updateFloorData.noOfRooms = FloorModelData.noOfRooms.ToString();
                updateFloorData.blocks_id = blockid;
                web.UpdateFloor(updateFloorData);
            }
        }
        bool validate()
        {
            if(string.IsNullOrEmpty(FloorModelData.floorNo)|| FloorModelData.floorNo.Length==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Floor No required", "OK");
                return false;
            }
            else if(string.IsNullOrEmpty(FloorModelData.noOfRooms.ToString()) || FloorModelData.floorNo.ToString().Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "No of rooms required", "OK");
                return false;
            }
            return true;
        }
        public async void FloorEditSucess(string resultHostel)
        {
            updateFloorData = new UpdateFloorData();
            FloorModelData = new FloorData();
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            OnPropertyChanged("FloorModelData");
        }

        public Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            throw new NotImplementedException();
        }

        public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            throw new NotImplementedException();
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }

        public Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            throw new NotImplementedException();
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }
}
