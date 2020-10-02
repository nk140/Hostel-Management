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
    public class EditRoomTypeVM : BaseViewModel, MasterI,EditRoomTypeI
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
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        public ObservableCollection<AreaModel> AreaLists
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaLists"); }
        }
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        public ObservableCollection<HostelModel> HostelLists
        {
            get { return hostelPresentmodels_; }
            set { hostelPresentmodels_ = value; OnPropertyChanged("HostelLists"); }
        }
        public ICommand UpdateCommand => new Command(OnUpdateCommand);
        public EditRoomTypeVM(string roomid, string userid, string hostelroomtypename, string hostelid)
        {
            UpdateRoomTypeModel.id = roomid;
            UpdateRoomTypeModel.userId = userid;
            UpdateRoomTypeModel.hostelRoomTypeName = hostelroomtypename;
            //UpdateRoomTypeModel.hostelId = hostelid;
            web = new MasterServices((MasterI)this,(EditRoomTypeI)this);
            web.GetAllArea();
        }
        public void GetHostelList(string areaid)
        {
            web.GetAllHostel(areaid);
        }
        public async void OnUpdateCommand()
        {
            if (validate())
            {
                UpdateRoomTypeModel.hostelId = App.hostelid;
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

        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelLists = HostelList;
            OnPropertyChanged("HostelLists");
        }

        public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            throw new NotImplementedException();
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
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
