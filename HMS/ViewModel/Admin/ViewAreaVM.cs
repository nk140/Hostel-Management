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
    public class ViewAreaVM : BaseViewModel, MasterI, DeleteAreaI
    {
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private ObservableCollection<StateModel> stateModels = new ObservableCollection<StateModel>();
        MasterServices web;
        private AreaModel _OldDisciplinaryData;

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
        public ICommand TapCommand => new Command<AreaModel>(OnTapCommand);
        public ViewAreaVM()
        {
            web = new MasterServices((MasterI)this, (DeleteAreaI)this);
            web.GetAllArea();
        }
        public async void OnEditCommand(AreaModel obj)
        {
            App.areaid = obj.id;
            await App.Current.MainPage.Navigation.PushModalAsync(new EditArea(obj.id, obj.areaName, obj.stateId));
            Hideorshowbutton(obj);
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
            var result = await App.Current.MainPage.DisplayActionSheet("Hostels and others are associated from this area want to delete.", "Cancel", null, "Yes", "No");
            if (result.Equals("Yes"))
            {
                web.DeleteArea(obj.id);
            }
            //Hideorshowbutton(obj);
        }
        public async void OnTapCommand(AreaModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(AreaModel obj)
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
                    foreach (var items in AreaLists)
                    {
                        if (_OldDisciplinaryData.areaName == items.areaName)
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
        public void UpdateProduct(AreaModel obj)
        {
            var index = AreaLists.IndexOf(obj);
            AreaLists.Remove(obj);
            AreaLists.Insert(index, obj);
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
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
            await App.Current.MainPage.DisplayAlert("HMS", "No Area List Found.", "OK");
            AreaLists.Clear();
            OnPropertyChanged("AreaLists");
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

        public async void NoListFound(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
    public class ViewBlockVM : BaseViewModel, MasterI, DeleteBlockI
    {
        MasterServices web;
        string hostelids, areaids;
        private ObservableCollection<BlockModel> blockModels_ = new ObservableCollection<BlockModel>();
        private BlockModel _OldDisciplinaryData;

        public ObservableCollection<BlockModel> BlockModelList
        {
            get { return blockModels_; }
            set { blockModels_ = value; OnPropertyChanged("BlockModelList"); }
        }
        public ICommand EditCommand => new Command<BlockModel>(OnEditCommand);
        public ICommand ViewFloorCommand => new Command<BlockModel>(OnViewFloorCommand);
        public ICommand DeleteCommand => new Command<BlockModel>(OnDeleteCommand);
        public ICommand TapCommand => new Command<BlockModel>(OnTapCommand);
        public ViewBlockVM(string hosteId, string areaids)
        {
            hostelids = hosteId;
            this.areaids = areaids;
            web = new MasterServices((MasterI)this, (DeleteBlockI)this);
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
            await App.Current.MainPage.Navigation.PushModalAsync(new EditBlock(obj.id, obj.name, hostelids, areaids));
        }
        public async void OnViewFloorCommand(BlockModel obj)
        {
            obj.hostelId = hostelids;
            App.hostelid = obj.hostelId;
            App.blockid = obj.id;
            //await App.Current.MainPage.Navigation.PushModalAsync(new ViewFloor(obj.hostelId));
        }
        public async void OnDeleteCommand(BlockModel obj)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Rooms and others are associated from this block want to delete.", "Cancel", null, "Yes", "No");
            if (result.Equals("Yes"))
            {
                web.DeleteBlock(obj.id);
            }
        }
        public async void OnTapCommand(BlockModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(BlockModel obj)
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
                    foreach (var items in BlockModelList)
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
        public void UpdateProduct(BlockModel obj)
        {
            var index = BlockModelList.IndexOf(obj);
            BlockModelList.Remove(obj);
            BlockModelList.Insert(index, obj);
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
            await App.Current.MainPage.DisplayAlert("HMS", "Block List Not Found.", "OK");
            BlockModelList.Clear();
            OnPropertyChanged("BlockModelList");
        }
        public async void NoListFound(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
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

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No Hostel For Searched area", "OK");
        }

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewFloorVM : BaseViewModel, MasterI, DeleteFloorI
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
        private FloorData _OldDisciplinaryData;

        public ICommand EditCommand => new Command<FloorData>(OnEditCommand);
        public ICommand ViewRoomCommand => new Command<FloorData>(OnViewRoomCommand);
        public ICommand DeleteCommand => new Command<FloorData>(OnDeleteCommand);
        public ICommand TapCommand => new Command<FloorData>(OnTapCommand);
        public ViewFloorVM(string hostelid, string blockid)
        {
            //this.blockid = blockid;
            hostelids = hostelid;
            this.blockid = blockid;
            // App.blockid = blockid;
            web = new MasterServices((MasterI)this, (DeleteFloorI)this);
            web.GetAllFloor(hostelids);
        }
        public async void OnEditCommand(FloorData obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditFloor(obj.id.ToString(), obj.floorNo, obj.hostelId.ToString(), obj.noOfRooms.ToString(), blockid));
        }
        public async void OnViewRoomCommand(FloorData obj)
        {
            App.floorid = obj.id.ToString();
            // await App.Current.MainPage.Navigation.PushModalAsync(new ViewRoom(obj.hostelId.ToString(), App.blockid));
        }
        public async void OnDeleteCommand(FloorData obj)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Rooms and others are associated from this floor want to delete.", "Cancel", null, "Yes", "No");
            if (result.Equals("Yes"))
            {
                web.DeleteFloor(obj.id.ToString());
            }
        }
        public async void OnTapCommand(FloorData obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(FloorData obj)
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
                    foreach (var items in FloorModelList)
                    {
                        if (_OldDisciplinaryData.floorNo == items.floorNo)
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
        public void UpdateProduct(FloorData obj)
        {
            var index = FloorModelList.IndexOf(obj);
            FloorModelList.Remove(obj);
            FloorModelList.Insert(index, obj);
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
            await App.Current.MainPage.DisplayAlert("HMS", "No Floor List Found.", "OK");
            FloorModelList.Clear();
            OnPropertyChanged("FloorModelList");
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
        public async void DeleteFloorSucess(string resultHostel)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            web.GetAllFloor(hostelids);
            OnPropertyChanged("FloorModelList");
        }

        public async void NoListFound(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
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
            await App.Current.MainPage.DisplayAlert("HMS", "No Hostel Found", "OK");
        }

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewRoomVM : BaseViewModel, RoomListI, DeleteRoomI
    {
        MasterServices web;
        string blockids, floorids, hostelids;
        private ObservableCollection<RoomNameList> roomNameLists = new ObservableCollection<RoomNameList>();
        private RoomNameList _OldDisciplinaryData;

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
        public ICommand TapCommand => new Command<RoomNameList>(OnTapCommand);
        public ViewRoomVM(string hostelid, string blockid, string floorid)
        {
            hostelids = hostelid;
            blockids = blockid;
            floorids = floorid;
            web = new MasterServices((RoomListI)this, (DeleteRoomI)this);
            web.RoomListname(hostelids, blockids);
        }
        public async void OnEditCommand(RoomNameList obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditRoom(obj.id, obj.name, hostelids, obj.hostelRoomTypeId, blockids, floorids, obj.noOfBed));
        }
        public async void OnViewRoomBedCommand(RoomNameList obj)
        {
            App.roomname = obj.name;
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewRoomBed(obj.name, App.hostelid));
        }
        public async void OnDeleteCommand(RoomNameList obj)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Room Beds are associated from this room want to delete.", "Cancel", null, "Yes", "No");
            if (result.Equals("Yes"))
            {
                web.DeleteRoom(obj.id);
            }
        }
        public async void OnTapCommand(RoomNameList obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(RoomNameList obj)
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
                    foreach (var items in RoomNameLists)
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
        public void UpdateProduct(RoomNameList obj)
        {
            var index = RoomNameLists.IndexOf(obj);
            RoomNameLists.Remove(obj);
            RoomNameLists.Insert(index, obj);
        }
        public async void DeleteRoomSucess(string resultHostel)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            web.RoomListname(hostelids, blockids);
            OnPropertyChanged("RoomNameLists");
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
            await App.Current.MainPage.DisplayAlert("HMS", "No Room List Found", "OK");
            RoomNameLists.Clear();
            OnPropertyChanged("RoomNameLists");
        }

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No Room List Found", "OK");
        }

        public async void LoadRoomList(ObservableCollection<RoomNameList> roomLists)
        {
            RoomNameLists = roomLists;
            OnPropertyChanged("RoomNameLists");
        }

        public async void NoListFound(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No Room List Found", "OK");
            RoomNameLists.Clear();
            OnPropertyChanged("RoomNameLists");
        }
    }
    public class ViewRoomTypeVM : BaseViewModel, RoomI, DeleteRoomTypeI
    {
        MasterServices web;
        private ObservableCollection<RoomTypeModel> roomTypeModel_ = new ObservableCollection<RoomTypeModel>();
        private RoomTypeModel _OldDisciplinaryData;

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
        public ICommand TapCommand => new Command<RoomTypeModel>(OnTapCommand);
        public ViewRoomTypeVM()
        {
            web = new MasterServices((RoomI)this, (DeleteRoomTypeI)this);
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
        public async void OnTapCommand(RoomTypeModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(RoomTypeModel obj)
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
                    foreach (var items in RoomTypeModels)
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
        public void UpdateProduct(RoomTypeModel obj)
        {
            var index = RoomTypeModels.IndexOf(obj);
            RoomTypeModels.Remove(obj);
            RoomTypeModels.Insert(index, obj);
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
            RoomTypeModels.Clear();
            OnPropertyChanged("RoomTypeModels");
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

        public async void NoListFound(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            RoomTypeModels.Clear();
            OnPropertyChanged("RoomTypeModels");
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
            web = new MasterServices((MasterI)this,(RoomListI)this);
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

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No hostel found.", "OK");
        }

        public async void LoadRoomList(ObservableCollection<RoomNameList> roomLists)
        {
            // RoomNameLists = roomLists;
            // OnPropertyChanged("RoomNameLists");
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewRoomBedVM : BaseViewModel, RoomBedI1, DeleteRoomBedI
    {
        MasterServices web;
        string hostelids;
        string roomnames;
        private ObservableCollection<RoomBedData> roomBedDatas = new ObservableCollection<RoomBedData>();
        private RoomBedData _OldDisciplinaryData;

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
        public ICommand TapCommand => new Command<RoomBedData>(OnTapCommand);
        public ViewRoomBedVM(string roomname, string hostelid)
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
        public async void OnTapCommand(RoomBedData obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(RoomBedData obj)
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
                    foreach (var items in RoomBedDatas)
                    {
                        if (_OldDisciplinaryData.bedNo == items.bedNo)
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
        public void UpdateProduct(RoomBedData obj)
        {
            var index = RoomBedDatas.IndexOf(obj);
            RoomBedDatas.Remove(obj);
            RoomBedDatas.Insert(index, obj);
        }
        public async void Failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            RoomBedDatas.Clear();
            OnPropertyChanged("RoomBedDatas");
        }

        public async void LoadRoomBedList(ObservableCollection<RoomBedData> roomBedDatas)
        {
            RoomBedDatas = roomBedDatas;
            OnPropertyChanged("RoomBedDatas");
        }

        public async void NoListFound(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
    public class ViewFilteredRoombedVM : BaseViewModel, MasterI, RoomListI
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
            web = new MasterServices((MasterI)this, (RoomListI)this);
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
        public void selectedhostelandblock(string hostelid, string blockid)
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

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No hostel found.", "OK");
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

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewHostelVM : BaseViewModel, MasterI, DeleteHostelI
    {
        MasterServices web;
        string AreaId;
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        private HostelModel _OldDisciplinaryData;

        public ObservableCollection<HostelModel> HostelLists
        {
            get { return hostelPresentmodels_; }
            set { hostelPresentmodels_ = value; OnPropertyChanged("HostelLists"); }
        }
        public ICommand EditCommand => new Command<HostelModel>(OnEditCommand);
        public ICommand ViewBlockCommand => new Command<HostelModel>(OnViewBlockCommand);
        public ICommand DeleteCommand => new Command<HostelModel>(OnDeleteCommand);
        public ICommand TapCommand => new Command<HostelModel>(OnTapCommand);
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
            // await App.Current.MainPage.Navigation.PushModalAsync(new ViewBlock(obj.id));
        }
        public async void OnDeleteCommand(HostelModel obj)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Blocks and others are associated from this hostel want to delete.", "Cancel", null, "Yes", "No");
            if (result.Equals("Yes"))
            {
                web.DeleteHostel(obj.id);
            }
        }
        public async void OnTapCommand(HostelModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(HostelModel obj)
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
                    foreach (var items in HostelLists)
                    {
                        if (_OldDisciplinaryData.hostelName == items.hostelName)
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
        public void UpdateProduct(HostelModel obj)
        {
            var index = HostelLists.IndexOf(obj);
            HostelLists.Remove(obj);
            HostelLists.Insert(index, obj);
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
            HostelLists.Clear();
            OnPropertyChanged("HostelLists");
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

        public async void NoListFound(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
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

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
          
        }

        public async Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            
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

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No Area found", "OK");
        }

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }
    public class ViewFacilityVM : BaseViewModel, ViewFacilityI, DeleteFasilityI
    {
        MasterServices web;
        private ObservableCollection<Models.ViewFacility> viewFacilities = new ObservableCollection<Models.ViewFacility>();
        private Models.ViewFacility _OldDisciplinaryData;

        public ObservableCollection<Models.ViewFacility> ViewFacilities
        {
            get
            {
                return viewFacilities;
            }
            set
            {
                viewFacilities = value;
                OnPropertyChanged("ViewFacilities");
            }
        }
        public ICommand DeleteFacilityCommand => new Command<Models.ViewFacility>(OnDeleteFacilityCommand);
        public ICommand EditFacilityCommand => new Command<Models.ViewFacility>(OnEditFacilityCommand);
        public ICommand TapCommand => new Command<Models.ViewFacility>(OnTapCommand);
        public ViewFacilityVM()
        {
            web = new MasterServices((ViewFacilityI)this, (DeleteFasilityI)this);
            web.ViewFacility();
        }
        public async void OnDeleteFacilityCommand(Models.ViewFacility obj)
        {
            web.DeleteFacility(obj.id);
        }
        public async void OnTapCommand(Models.ViewFacility obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(Models.ViewFacility obj)
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
                    foreach (var items in ViewFacilities)
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
        public void UpdateProduct(Models.ViewFacility obj)
        {
            var index = ViewFacilities.IndexOf(obj);
            ViewFacilities.Remove(obj);
            ViewFacilities.Insert(index, obj);
        }
        public async void OnEditFacilityCommand(Models.ViewFacility obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditFacility(obj.id, obj.name, App.userid));
        }
        public void LoadFacilityList()
        {

        }

        public async void LoadFacilityList(ObservableCollection<Models.ViewFacility> viewFacilities)
        {
            ViewFacilities = viewFacilities;
            OnPropertyChanged("ViewFacilities");
        }

        public async void PostFasilitySuccess(string resultHostel)
        {
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            web.ViewFacility();
        }
        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            ViewFacilities.Clear();
            OnPropertyChanged("ViewFacilities");
        }
    }
    public class ViewDisciplinaryTypeVM : BaseViewModel, ViewIDisciplinary, IDeleteDisciplinary
    {
        MasterServices web;
        private ObservableCollection<Models.ViewDisciplinaryType> viewDisciplinaryTypes = new ObservableCollection<Models.ViewDisciplinaryType>();
        private Models.ViewDisciplinaryType _OldDisciplinaryData;

        public ObservableCollection<Models.ViewDisciplinaryType> ViewDisciplinaryTypes
        {
            get
            {
                return viewDisciplinaryTypes;
            }
            set
            {
                viewDisciplinaryTypes = value;
                OnPropertyChanged("ViewDisciplinaryTypes");
            }
        }
        public ICommand DeleteDisciplinaryCommand => new Command<Models.ViewDisciplinaryType>(OnDeleteDisciplinaryCommand);
        public ICommand EditDisciplinaryCommand => new Command<Models.ViewDisciplinaryType>(OnEditDisciplinaryCommand);
        public ICommand TapCommand => new Command<Models.ViewDisciplinaryType>(OnTapCommand);
        public ViewDisciplinaryTypeVM()
        {
            web = new MasterServices((ViewIDisciplinary)this, (IDeleteDisciplinary)this);
            web.ViewDisciplinaryType();
        }
        public async void OnDeleteDisciplinaryCommand(Models.ViewDisciplinaryType obj)
        {
            web.DeleteDisciplinaryType(obj.id);
        }
        public async void OnEditDisciplinaryCommand(Models.ViewDisciplinaryType obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditDisciplinaryType(obj.id, obj.name, App.userid));
        }
        public async void DeleteDisciplinaryType(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            web.ViewDisciplinaryType();
        }
        public async void OnTapCommand(Models.ViewDisciplinaryType obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(Models.ViewDisciplinaryType obj)
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
                    foreach (var items in ViewDisciplinaryTypes)
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
        public void UpdateProduct(Models.ViewDisciplinaryType obj)
        {
            var index = ViewDisciplinaryTypes.IndexOf(obj);
            ViewDisciplinaryTypes.Remove(obj);
            ViewDisciplinaryTypes.Insert(index, obj);
        }
        public async void Failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void LoadDisciplinaryList(ObservableCollection<Models.ViewDisciplinaryType> viewDisciplinaryTypes)
        {
            ViewDisciplinaryTypes = viewDisciplinaryTypes;
            OnPropertyChanged("ViewDisciplinaryTypes");
        }

        public async void ServiceFailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            ViewDisciplinaryTypes.Clear();
            OnPropertyChanged("ViewDisciplinaryTypes");
        }
    }
}
