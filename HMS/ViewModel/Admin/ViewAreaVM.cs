using HMS.Data;
using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class ViewAreaVM : BaseViewModel, MasterI,DeleteAreaI
    {
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private ObservableCollection<StateModel> stateModels = new ObservableCollection<StateModel>();
        MasterServices web;
        public ObservableCollection<AreaModel> AreaLists
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaLists"); }
        }
        public ObservableCollection<StateModel> StateModels
        {
            get { return stateModels; }
            set { stateModels = value; OnPropertyChanged("StateModels"); }
        }
        public ICommand EditCommand => new Command<AreaModel>(OnEditCommand);
        public ICommand ViewHostelCommand => new Command<AreaModel>(OnViewHostelCommand);
        public ICommand DeleteCommand => new Command<AreaModel>(OnDeleteCommand);
        public ViewAreaVM()
        {
            web = new MasterServices((MasterI)this,(DeleteAreaI)this);
            web.GetAllArea();
        }
        public async void OnEditCommand(AreaModel obj)
        {
            App.areaid = obj.id;
            await App.Current.MainPage.Navigation.PushModalAsync(new EditArea(obj.id, obj.areaName, obj.stateId));
        }
        public async void OnViewHostelCommand(AreaModel obj)
        {
            App.areaid = obj.id;
           // await App.Current.MainPage.DisplayAlert("HMS", "Cant View Hostel From Here.", "OK");
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewHostel(App.areaid));
            //await App.Current.MainPage.Navigation.PushModalAsync(new EditArea(obj.id,obj.areaName));
        }
        public async void OnDeleteCommand(AreaModel obj)
        {
            web.DeleteArea(obj.id);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public  Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
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

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", index.ToString(), "OK");
        }

        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void DeleteAreaSucess(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            web.GetAllArea();
        }
    }
    public class ViewBlockVM : BaseViewModel, MasterI,DeleteBlockI
    {
        MasterServices web;
        string hostelids;
        private ObservableCollection<BlockModel> blockModels_ = new ObservableCollection<BlockModel>();
        public ObservableCollection<BlockModel> BlockModelList
        {
            get { return blockModels_; }
            set { blockModels_ = value; OnPropertyChanged("BlockModelList"); }
        }
        public ICommand EditCommand => new Command<BlockModel>(OnEditCommand);
        public ICommand ViewFloorCommand => new Command<BlockModel>(OnViewFloorCommand);
        public ICommand DeleteCommand => new Command<BlockModel>(OnDeleteCommand);
        public ViewBlockVM(string hosteId)
        {
            hostelids = hosteId;
            web = new MasterServices((MasterI)this,(DeleteBlockI)this);
            web.GetAllBlock(hosteId);
            //MessagingCenter.Subscribe<EditBlock>(this, "Updated Block", (obj) =>
            //{
            //    web.GetAllBlock(hosteId);
            //});
        }
        public async void OnEditCommand(BlockModel obj)
        {
           // App.hostelid = obj.hostelId;
            App.blockid = obj.id;
            await App.Current.MainPage.Navigation.PushModalAsync(new EditBlock(obj.id, obj.name));
        }
        public async void OnViewFloorCommand(BlockModel obj)
        {
            obj.hostelId = hostelids;
            App.hostelid = obj.hostelId;
            App.blockid = obj.id;
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewFloor(obj.hostelId));
        }
        public async void OnDeleteCommand(BlockModel obj)
        {
            web.DeleteBlock(obj.id);
        }
        public Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            throw new NotImplementedException();
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            BlockModelList = BlockList;
            OnPropertyChanged("BlockList");
        }

        public async Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
           
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
           
        }

        public async Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
           
        }

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", index.ToString(), "OK");
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void DeleteBlockSucess(string resultBlock)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultBlock, "OK");
            web.GetAllBlock(hostelids);
        }
    }
    public class ViewFilteredBlockVM : BaseViewModel, MasterI
    {
        MasterServices web;
        string hostelids;
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        public ObservableCollection<HostelModel> HostelLists
        {
            get { return hostelPresentmodels_; }
            set { hostelPresentmodels_ = value; OnPropertyChanged("HostelLists"); }
        }
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        //private ObservableCollection<StateModel> stateModels = new ObservableCollection<StateModel>();
        public ObservableCollection<AreaModel> AreaLists
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaLists"); }
        }
        public ViewFilteredBlockVM()
        {
            //hostelids = hosteId;
            web = new MasterServices(this);
            web.GetAllArea();
            //web.GetAllHostel(App.areaid);
        }
        public void selectedarea(string id)
        {
            web.GetAllHostel(id);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
           // BlockModelList = BlockList;
           // OnPropertyChanged("BlockModelList");
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelLists = HostelList;
            OnPropertyChanged("HostelLists");
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewFloorVM : BaseViewModel, MasterI,DeleteFloorI
    {
        private ObservableCollection<FloorData> floorModel_ = new ObservableCollection<FloorData>();
        public ObservableCollection<FloorData> FloorModelList
        {
            get { return floorModel_; }
            set { floorModel_ = value; OnPropertyChanged("FloorModelList"); }
        }
        public string blockid;
        string hostelids;
        MasterServices web;
        public ICommand EditCommand => new Command<FloorData>(OnEditCommand);
        public ICommand ViewRoomCommand => new Command<FloorData>(OnViewRoomCommand);
        public ICommand DeleteCommand => new Command<FloorData>(OnDeleteCommand);
        public ViewFloorVM(string hostelid)
        {
            //this.blockid = blockid;
            hostelids = hostelid;
            App.hostelid = hostelids;
           // App.blockid = blockid;
            web = new MasterServices((MasterI)this,(DeleteFloorI)this);
            web.GetAllFloor(hostelids);
        }
        public async void OnEditCommand(FloorData obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditFloor(obj.id.ToString(),obj.floorNo,obj.hostelId.ToString(),obj.noOfRooms.ToString(),App.blockid));
        }
        public async void OnViewRoomCommand(FloorData obj)
        {
            App.floorid = obj.id.ToString();
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewRoom(obj.hostelId.ToString(), App.blockid));
        }
        public async void OnDeleteCommand(FloorData obj)
        {
            web.DeleteFloor(obj.id.ToString());
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
           
        }

        public async Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            FloorModelList = FloorList;
            OnPropertyChanged("FloorModelList");
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            
        }

        public async Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            
        }

        public async Task ServiceFailed(int index)
        {
            
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void DeleteFloorSucess(string resultHostel)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            web.GetAllFloor(hostelids);
        }
    }
    public class ViewFilteredFloorVM : BaseViewModel, MasterI
    {
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
        private ObservableCollection<BlockModel> blockModels_ = new ObservableCollection<BlockModel>();
        public ObservableCollection<BlockModel> BlockModelList
        {
            get { return blockModels_; }
            set { blockModels_ = value; OnPropertyChanged("BlockModelList"); }
        }
        public string blockid;
        string hostelids;
        MasterServices web;
        public ViewFilteredFloorVM()
        {
            //this.blockid = blockid;
            //hostelids = hostelid;
            //App.hostelid = hostelids;
            //App.blockid = blockid;
            web = new MasterServices((MasterI)this);
            web.GetAllArea();
        }
        public void selectedarea(string id)
        {
            web.GetAllHostel(id);
        }
        public void selectedhostel(string id)
        {
            web.GetAllBlock(id);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            BlockModelList = BlockList;
            OnPropertyChanged("BlockModelList");
        }

        public async Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            //FloorModelList = FloorList;
           // OnPropertyChanged("FloorModelList");
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelLists = HostelList;
            OnPropertyChanged("HostelLists");
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No Area Found", "OK");
        }
    }

    public class ViewRoomVM : BaseViewModel,RoomListI, DeleteRoomI
    {
        MasterServices web;
        private ObservableCollection<RoomNameList> roomNameLists = new ObservableCollection<RoomNameList>();
        public ObservableCollection<RoomNameList> RoomNameLists
        {
            get
            {
                return roomNameLists;
            }
            set
            {
                roomNameLists = value;
                OnPropertyChanged("RoomNameLists");
            }
        }
        public ICommand EditCommand => new Command<RoomNameList>(OnEditCommand);
        public ICommand ViewRoomBedCommand => new Command<RoomNameList>(OnViewRoomBedCommand);
        public ICommand DeleteCommand => new Command<RoomNameList>(OnDeleteCommand);
        public ViewRoomVM(string hostelid,string blockid)
        {
            App.hostelid = hostelid;
            App.blockid = blockid;
            web = new MasterServices((RoomListI)this, (DeleteRoomI)this);
            web.RoomListname(App.hostelid, App.blockid);
        }
        public async void OnEditCommand(RoomNameList obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditRoom(obj.id,obj.name,App.hostelid,obj.hostelRoomTypeId,App.blockid,App.floorid,obj.noOfBed));
        }
        public async void OnViewRoomBedCommand(RoomNameList obj)
        {
            App.roomname = obj.name;
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewRoomBed(obj.name, App.hostelid));
        }
        public async void OnDeleteCommand(RoomNameList obj)
        {
            web.DeleteRoom(obj.id);
            web.RoomListname(App.hostelid, App.blockid);
        }
        public async void DeleteRoomSucess(string resultHostel)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
        }

        //public Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        //{
        //    throw new NotImplementedException();
        //}

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }

        public async void LoadRoomList(ObservableCollection<RoomNameList> roomLists)
        {
            RoomNameLists = roomLists;
            OnPropertyChanged("RoomNameLists");
        }
    }
    public class ViewRoomTypeVM : BaseViewModel,RoomI,DeleteRoomTypeI
    {
        MasterServices web;
        private ObservableCollection<RoomTypeModel> roomTypeModel_ = new ObservableCollection<RoomTypeModel>();
        public ObservableCollection<RoomTypeModel> RoomTypeModels
        {
            get
            {
                return roomTypeModel_;
            }
            set
            {
                roomTypeModel_ = value;
                OnPropertyChanged("RoomTypeModels");
            }
        }
        public ICommand EditCommand => new Command<RoomTypeModel>(OnEditCommand);
        public ICommand DeleteCommand => new Command<RoomTypeModel>(OnDeleteCommand);
        public ViewRoomTypeVM()
        {
            web = new MasterServices((RoomI)this,(DeleteRoomTypeI)this);
            web.GetAllRomType1();
        }
        public async void OnEditCommand(RoomTypeModel obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditRoomType(obj.id, App.userid, obj.name, App.hostelid));
        }
        public async void OnDeleteCommand(RoomTypeModel obj)
        {
            web.DeleteRoomType(obj.id);
        }
        public async Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes)
        {
            RoomTypeModels = RoomTypes;
            OnPropertyChanged("RoomTypeModels");
        }

        public Task PostRoomSuccess(string resultHostel)
        {
            throw new NotImplementedException();
        }

        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        //public Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task ServiceFailed(int index)
        //{
        //    throw new NotImplementedException();
        //}

        void DeleteRoomTypeI.ServiceFaild(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void DeleteRoomTypeSuccess(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            web.GetAllRomType1();
        }
    }

    public class ViewFilteredRoomVM : BaseViewModel, MasterI, RoomListI
    {
        MasterServices web;
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
        private ObservableCollection<BlockModel> blockModels_ = new ObservableCollection<BlockModel>();
        public ObservableCollection<BlockModel> BlockModelList
        {
            get { return blockModels_; }
            set { blockModels_ = value; OnPropertyChanged("BlockModelList"); }
        }
        private ObservableCollection<FloorData> floorModel_ = new ObservableCollection<FloorData>();
        public ObservableCollection<FloorData> FloorModelList
        {
            get { return floorModel_; }
            set { floorModel_ = value; OnPropertyChanged("FloorList"); }
        }
        public ViewFilteredRoomVM()
        {
            //App.hostelid = hostelid;
            //App.blockid = blockid;
            web = new MasterServices(this);
            web.GetAllArea();
           // web.GetAllHostel();
           // web.GetAllBlock(hostelid);
        }
        public void selectedarea(string id)
        {
            web.GetAllHostel(id);
        }
        public void selectedblock(string hostelid)
        {
            web.GetAllBlock(hostelid);
            web.GetAllFloor(hostelid);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            BlockModelList = BlockList;
            OnPropertyChanged("BlockModelList");
        }

        public async Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            FloorModelList = FloorList;
            OnPropertyChanged("FloorModelList");
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelLists = HostelList;
            OnPropertyChanged("HostelLists");
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }

        public async void LoadRoomList(ObservableCollection<RoomNameList> roomLists)
        {
           // RoomNameLists = roomLists;
           // OnPropertyChanged("RoomNameLists");
        }

        public void ServiceFaild(string result)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewRoomBedVM : BaseViewModel,RoomBedI1, DeleteRoomBedI
    {
        MasterServices web;
        string hostelids;
        string roomnames;
        private ObservableCollection<RoomBedData> roomBedDatas = new ObservableCollection<RoomBedData>();
        public ObservableCollection<RoomBedData> RoomBedDatas
        {
            get
            {
                return roomBedDatas;
            }
            set
            {
                roomBedDatas = value;
                OnPropertyChanged("RoomBedDatas");
            }
        }
        public ICommand EditCommand => new Command<RoomBedData>(OnEditCommand);
        public ICommand DeleteCommand => new Command<RoomBedData>(OnDeleteCommand);
        public ViewRoomBedVM(string roomname,string hostelid)
        {
            hostelids = hostelid;
            roomnames = roomname;
            web = new MasterServices((RoomBedI1)this, (DeleteRoomBedI)this);
            web.GetRoomBedList(hostelid);
        }
        public async void OnEditCommand(RoomBedData obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditRoomBed(roomnames, obj.bedId, obj.bedNo, obj.hostelRoomId, obj.hostelId));
        }
        public async void OnDeleteCommand(RoomBedData obj)
        {
            web.DeleteRoomBed(obj.bedId);
        }
        public async void DeleteRoomBedSucess(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            web.GetRoomBedList(hostelids);
        }

        public async void Failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void LoadRoomBedList(ObservableCollection<RoomBedData> roomBedDatas)
        {
            RoomBedDatas = roomBedDatas;
            OnPropertyChanged("RoomBedDatas");
        }
    }
    public class  ViewFilteredRoombedVM : BaseViewModel, MasterI, RoomListI
    {
        MasterServices web;
        string hostelids;
        string roomnames;
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        //private ObservableCollection<StateModel> stateModels = new ObservableCollection<StateModel>();
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
        private ObservableCollection<BlockModel> blockModels_ = new ObservableCollection<BlockModel>();
        public ObservableCollection<BlockModel> BlockModelList
        {
            get { return blockModels_; }
            set { blockModels_ = value; OnPropertyChanged("BlockModelList"); }
        }
        private ObservableCollection<RoomNameList> roomNameLists = new ObservableCollection<RoomNameList>();
        public ObservableCollection<RoomNameList> RoomNameLists
        {
            get
            {
                return roomNameLists;
            }
            set
            {
                roomNameLists = value;
                OnPropertyChanged("RoomNameLists");
            }
        }
        private ObservableCollection<RoomBedData> roomBedDatas = new ObservableCollection<RoomBedData>();
        public ObservableCollection<RoomBedData> RoomBedDatas
        {
            get
            {
                return roomBedDatas;
            }
            set
            {
                roomBedDatas = value;
                OnPropertyChanged("RoomBedDatas");
            }
        }
        public ViewFilteredRoombedVM()
        {
            web = new MasterServices((MasterI)this,(RoomListI)this);
            web.GetAllArea();
        }
        public void selectedarea(string areaid)
        {
            web.GetAllHostel(areaid);
        }
        public void selectedhostel(string hostelid)
        {
            web.GetAllBlock(hostelid);
        }
        public void selectedhostelandblock(string hostelid,string blockid)
        {
            web.RoomListname(hostelid, blockid);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            BlockModelList = BlockList;
            OnPropertyChanged("BlockModelList");
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelLists = HostelList;
            OnPropertyChanged("HostelLists");
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }

        public async void LoadRoomList(ObservableCollection<RoomNameList> roomLists)
        {
            RoomNameLists = roomLists;
            OnPropertyChanged("roomNameLists");
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }

    public class ViewHostelVM : BaseViewModel, MasterI,DeleteHostelI
    {
        MasterServices web;
        string AreaId;
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        public ObservableCollection<HostelModel> HostelLists
        {
            get { return hostelPresentmodels_; }
            set { hostelPresentmodels_ = value; OnPropertyChanged("HostelLists"); }
        }
        public ICommand EditCommand => new Command<HostelModel>(OnEditCommand);
        public ICommand ViewBlockCommand => new Command<HostelModel>(OnViewBlockCommand);
        public ICommand DeleteCommand => new Command<HostelModel>(OnDeleteCommand);
        public ViewHostelVM(string areaid)
        {
           // MessagingCenter.Subscribe<FilterPopup>(this,"")
            AreaId = areaid;
            App.areaid = AreaId;
            web = new MasterServices((MasterI)this, (DeleteHostelI)this);
            web.GetAllHostel(areaid);
        }
        public async void OnEditCommand(HostelModel obj)
        {
            obj.areaId = AreaId;
            App.hostelid = obj.id;
            await App.Current.MainPage.Navigation.PushModalAsync(new EditHostel(obj.id, obj.hostelName, obj.areaId, obj.zipCode, obj.addressLine1, obj.phoneNo, obj.email, obj.hostelForGender));
        }
        public async void OnViewBlockCommand(HostelModel obj)
        {
            App.hostelid = obj.id;
           // App.areaid = obj.areaId;
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewBlock(obj.id));
        }
        public async void OnDeleteCommand(HostelModel obj)
        {
            web.DeleteHostel(obj.id);
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

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelLists = HostelList;
            OnPropertyChanged("HostelLists");
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", index.ToString(), "OK");
        }

        public async void ServiceFaild(string responseresult)
        {
            await App.Current.MainPage.DisplayAlert("HMS", responseresult, "OK");
        }

        public async void DeleteHostelNameSuccess(string resultHostel)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            web.GetAllHostel(AreaId);
        }
    }
    public class ViewFilteredHostelVM : BaseViewModel, MasterI
    {
        MasterServices web;
        string AreaId;
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        //private ObservableCollection<StateModel> stateModels = new ObservableCollection<StateModel>();
        public ObservableCollection<AreaModel> AreaLists
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaLists"); }
        }
        public ViewFilteredHostelVM()
        {
           // AreaId = areaid;
            web = new MasterServices(this);
            web.GetAllArea();
            //web.GetAllHostel(areaid);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            throw new NotImplementedException();
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            //HostelLists = HostelList;
            //OnPropertyChanged("HostelLists");
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }
    }
    public class ViewFacilityVM:BaseViewModel
    {

    }
}
