using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class RoomVM : BaseViewModel, MasterI, RoomI
    {
        public RoomVM()
        {
            web = new MasterServices(this, this);
            RoomProperty = new Properties();
            web.GetAllRomType1();
            web.GetAllArea();
        }

        MasterServices web;
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        private ObservableCollection<BlockModel> blockModels_ = new ObservableCollection<BlockModel>();
        private ObservableCollection<RoomTypeModel> roomTypeModel_ = new ObservableCollection<RoomTypeModel>();
        private ObservableCollection<FloorData> floorModel_ = new ObservableCollection<FloorData>();
        private RoomModel room_ = new RoomModel();
        private Properties properties_ = new Properties();

        #region AssignVariableAndObj
        public ObservableCollection<AreaModel> AreaModelList
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaModelList"); }
        }
        public ObservableCollection<HostelModel> HostelModelList
        {
            get { return hostelPresentmodels_; }
            set { hostelPresentmodels_ = value; OnPropertyChanged("HostelModelList"); }
        }

        public ObservableCollection<BlockModel> BlockModelList
        {
            get { return blockModels_; }
            set { blockModels_ = value; OnPropertyChanged("BlockModelList"); }
        }

        public ObservableCollection<RoomTypeModel> RoomTypeList
        {
            get { return roomTypeModel_; }
            set { roomTypeModel_ = value; OnPropertyChanged("RoomTypeList"); }
        }


        public ObservableCollection<FloorData> FloorModelList
        {
            get { return floorModel_; }
            set { floorModel_ = value; OnPropertyChanged("FloorList"); }
        }

        public RoomModel RoomData
        {
            get { return room_; }
            set { room_ = value; OnPropertyChanged("RoomData"); }
        }


        public Properties RoomProperty
        {
            get { return properties_; }
            set { properties_ = value; OnPropertyChanged("RoomProperty"); }
        }



        #endregion

        #region Commands
        public Command SetAreaVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (AreaModelList != null)
                    {
                        if (AreaModelList.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Area", "OK");
                            RoomProperty.AreaVisible = false;
                        }
                        else
                        {
                            RoomProperty.AreaHeight = (40 * AreaModelList.Count) + 20;
                            RoomProperty.AreaVisible = !RoomProperty.AreaVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Area", "OK");
                        RoomProperty.AreaVisible = false;
                    }


                    OnPropertyChanged("RoomProperty");
                });
            }
        }
        public Command SetHostelVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (HostelModelList != null)
                    {
                        if (HostelModelList.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Hostel", "OK");
                            RoomProperty.HostelVisible = false;
                        }
                        else
                        {
                            RoomProperty.HostelHeight = (40 * HostelModelList.Count) + 20;
                            RoomProperty.HostelVisible = !RoomProperty.HostelVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Hostel", "OK");
                        RoomProperty.HostelVisible = false;
                    }


                    OnPropertyChanged("RoomProperty");
                });
            }
        }
        public Command SetBlockVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (BlockModelList != null)
                    {
                        if (BlockModelList.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Block", "OK");
                            RoomProperty.BlockVisible = false;
                        }
                        else
                        {
                            RoomProperty.BlockHeight = (40 * BlockModelList.Count) + 20;
                            RoomProperty.BlockVisible = !RoomProperty.BlockVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Block", "OK");
                        RoomProperty.BlockVisible = false;
                    }


                    OnPropertyChanged("RoomProperty");
                });
            }
        }

        public Command SetFloorVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (FloorModelList != null)
                    {
                        if (FloorModelList.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Floor", "OK");
                            RoomProperty.FloorVisible = false;
                        }
                        else
                        {
                            RoomProperty.FloorHeight = (40 * FloorModelList.Count) + 20;
                            RoomProperty.FloorVisible = !RoomProperty.FloorVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Room Type", "OK");
                        RoomProperty.FloorVisible = false;
                    }


                    OnPropertyChanged("RoomProperty");
                });
            }
        }

        public Command SetRoomTypeVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (RoomTypeList != null)
                    {
                        if (RoomTypeList.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Block", "OK");
                            RoomProperty.RoomTypeVisible = false;
                        }
                        else
                        {
                            RoomProperty.RoomTypeHeight = (40 * RoomTypeList.Count) + 20;
                            RoomProperty.RoomTypeVisible = !RoomProperty.RoomTypeVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Room Type", "OK");
                        RoomProperty.RoomTypeVisible = false;
                    }


                    OnPropertyChanged("RoomProperty");
                });
            }
        }


        public Command SaveCommand
        {
            get
            {
                return new Command(() => { SaveAsync(); });
            }
        }
        public void SaveAsync()
        {

            //  Hostel.hostelName = HostelName;
            if (RoomData.areaId == null || RoomData.areaId.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select Area", "OK");
            }
            else if (RoomData.hostelId == null || RoomData.hostelId.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select Hostel", "OK");
            }
            else if (RoomData.blockId == null || RoomData.blockId.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select Block", "OK");
            }
            else if (RoomData.floorId == null || RoomData.floorId.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select Floor", "OK");
            }
            else if (RoomData.name == null || RoomData.name.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Enter Room Name", "OK");
            }
            else if (RoomData.bedno == null || RoomData.bedno.Length == 0)
                App.Current.MainPage.DisplayAlert("HMS", "Please Enter No of beds", "OK");
            else
            {
                RoomDataModel roomDataModel = new RoomDataModel();
                roomDataModel.roomName = RoomData.name;
                roomDataModel.hostelId = RoomData.hostelId;
                roomDataModel.hostelRoomTypeId = RoomData.hostelRoomTypeId;
                roomDataModel.hostelBlockId = RoomData.blockId;
                roomDataModel.floorId = RoomData.floorId;
                roomDataModel.noOfBeds = RoomData.bedno;
                web.SaveRoomEntry(roomDataModel);
            }
        }

        #endregion

        public void AreaSelection(int index)
        {
            RoomProperty.AreaVisible = !RoomProperty.AreaVisible;//true

            // display entry selected text value
            RoomProperty.AreaName = AreaModelList[index].areaName;

            RoomData.areaId = AreaModelList[index].id;
            RoomData.hostelId = "";
            RoomProperty.HostelName = "";
            OnPropertyChanged("RoomProperty");
            web.GetAllHostel(AreaModelList[index]);

        }

        public void HostelSelection(int index)
        {
            RoomProperty.HostelVisible = !RoomProperty.HostelVisible;//true

            // display entry selected text value
            RoomProperty.HostelName = HostelModelList[index].hostelName;
            RoomData.hostelId = HostelModelList[index].id;
            RoomData.blockId = "";
            RoomProperty.BlockName = "";
            OnPropertyChanged("RoomProperty");
            web.GetAllBlock(RoomData.areaId, RoomData.hostelId);

        }

        public void BlockSelection(int index)
        {
            RoomProperty.BlockVisible = !RoomProperty.BlockVisible;//true

            // display entry selected text value
            RoomProperty.BlockName = BlockModelList[index].name;
            RoomData.blockId = BlockModelList[index].id;
            RoomData.floorId = "";
            RoomProperty.FloorName = "";
            OnPropertyChanged("RoomProperty");

            web.GetAllFloor(RoomData.hostelId);
        }

        public void FloorSelection(int index)
        {
            RoomProperty.FloorVisible = !RoomProperty.FloorVisible;//true

            //// display entry selected text value
            RoomProperty.FloorName = FloorModelList[index].floorNo;
            RoomData.floorId = FloorModelList[index].id.ToString();
            RoomData.floorName = FloorModelList[index].floorNo;
            OnPropertyChanged("RoomProperty");


        }

        public void RoomTypeSelection(int index)
        {
            RoomProperty.RoomTypeVisible = !RoomProperty.RoomTypeVisible;//true

            // display entry selected text value
            RoomProperty.RoomType = RoomTypeList[index].name;
            RoomData.hostelRoomTypeId = RoomTypeList[index].id;
            OnPropertyChanged("RoomProperty");


        }


        #region implementation

        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaModelList = new ObservableCollection<AreaModel>();
            AreaModelList = AreaList;
            OnPropertyChanged("AreaModelList");
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelModelList = new ObservableCollection<HostelModel>();
            HostelModelList = HostelList;
            OnPropertyChanged("HostelModelList");
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            BlockModelList = new ObservableCollection<BlockModel>();
            BlockModelList = BlockList;
            OnPropertyChanged("BlockModelList");
        }

        public async Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            FloorModelList = new ObservableCollection<FloorData>();
            FloorModelList = FloorList;
            OnPropertyChanged("FloorModelList");
        }

        public async Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {

        }

        public async Task ServiceFailed(int index)
        {

        }

        public async Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes)
        {
            RoomTypeList = new ObservableCollection<RoomTypeModel>();
            RoomTypeList = RoomTypes;
            OnPropertyChanged("RoomTypeList");
        }

        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("", result, "OK");
        }

        public async Task PostRoomSuccess(string resultHostel)
        {
            RoomData.name = string.Empty;
            RoomData.bedno = string.Empty;
            RoomProperty.RoomType = string.Empty;
            RoomProperty.FloorName = string.Empty;
            RoomProperty.BlockName = string.Empty;
            RoomProperty.HostelName = string.Empty;
            RoomProperty.AreaName = string.Empty;
            await App.Current.MainPage.DisplayAlert("", resultHostel, "OK");
            OnPropertyChanged("RoomData");
            OnPropertyChanged("RoomProperty");
        }
        #endregion

    }
}
