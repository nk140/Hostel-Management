using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class FloorVM : BaseViewModel, MasterI, FloorI
    {
        public FloorVM()
        {
            FloorProp.AreaVisible = false;
            FloorProp.HostelVisible = false;
            FloorProp.BlockVisible = false;
            FloorData = new FloorModel();
            web = new MasterServices(this, this);
            // send id into base 64 formate
            web.GetAllArea();
            web.GetAllRomType();
        }


        MasterServices web;
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        private ObservableCollection<BlockModel> blockModels_ = new ObservableCollection<BlockModel>();
        private ObservableCollection<RoomTypeModel> roomTypeModel_ = new ObservableCollection<RoomTypeModel>();
        private FloorModel floor_ = new FloorModel();

        Properties FloorProp_ = new Properties();


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

        public FloorModel FloorData
        {
            get { return floor_; }
            set { floor_ = value; OnPropertyChanged("FloorData"); }
        }

        public Properties FloorProp
        {
            get { return FloorProp_; }
            set { FloorProp_ = value; OnPropertyChanged("FloorProp"); }
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
                            FloorProp.AreaVisible = false;
                        }
                        else
                        {
                            FloorProp.AreaHeight = (40 * AreaModelList.Count) + 20;
                            FloorProp.AreaVisible = !FloorProp.AreaVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Area", "OK");
                        FloorProp.AreaVisible = false;
                    }


                    OnPropertyChanged("FloorProp");
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
                            FloorProp.HostelVisible = false;
                        }
                        else
                        {
                            FloorProp.HostelHeight = (40 * HostelModelList.Count) + 20;
                            FloorProp.HostelVisible = !FloorProp.HostelVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Hostel", "OK");
                        FloorProp.HostelVisible = false;
                    }


                    OnPropertyChanged("FloorProp");
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
                            FloorProp.BlockVisible = false;
                        }
                        else
                        {
                            FloorProp.BlockHeight = (40 * BlockModelList.Count) + 20;
                            FloorProp.BlockVisible = !FloorProp.BlockVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Block", "OK");
                        FloorProp.BlockVisible = false;
                    }


                    OnPropertyChanged("FloorProp");
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
                            FloorProp.RoomTypeVisible = false;
                        }
                        else
                        {
                            FloorProp.RoomTypeHeight = (40 * RoomTypeList.Count) + 20;
                            FloorProp.RoomTypeVisible = !FloorProp.RoomTypeVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Room Type", "OK");
                        FloorProp.RoomTypeVisible = false;
                    }


                    OnPropertyChanged("FloorProp");
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
            if (FloorData.hostelId == null || FloorData.hostelId.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select Hostel", "OK");
            }
            else if (FloorData.blocks_id == null || FloorData.blocks_id.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select Block", "OK");
            }
            else if (FloorData.floorName == null || FloorData.floorName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Enter Floor Name", "OK");
            }
            else if (FloorData.noOfRooms == null || FloorData.noOfRooms.Length == 0)
                App.Current.MainPage.DisplayAlert("", "Please Enter Room No", "OK");
            else
            {
                web.SaveFloorEntry(FloorData);
            }
        }

        #endregion


        public void AreaSelection(int index)
        {
            FloorProp.AreaVisible = !FloorProp.AreaVisible;//true

            // display entry selected text value
            FloorProp.AreaName = AreaModelList[index].areaName;

            // FloorData.areaId = AreaModelList[index].id;
            FloorData.hostelId = "";
            FloorProp.HostelName = "";
            OnPropertyChanged("FloorProp");
            //web.GetAllHostel(AreaModelList[index]);
        }
        public void selectedArea(string id)
        {
            web.GetAllHostel(id);
        }

        public void HostelSelection(int index)
        {
            FloorProp.HostelVisible = !FloorProp.HostelVisible;//true

            // display entry selected text value
            FloorProp.HostelName = HostelModelList[index].hostelName;
            FloorData.hostelId = HostelModelList[index].id;
            FloorData.blocks_id = "";
            FloorProp.BlockName = "";
            OnPropertyChanged("FloorProp");
            web.GetAllBlock(FloorData.hostelId);

        }

        public void BlockSelection(int index)
        {
            FloorProp.BlockVisible = !FloorProp.BlockVisible;//true

            // display entry selected text value
            FloorProp.BlockName = BlockModelList[index].name;
            FloorData.blocks_id = BlockModelList[index].id;
            OnPropertyChanged("FloorProp");



        }

        public void RoomTypeSelection(int index)
        {
            //FloorProp.RoomTypeVisible = !FloorProp.RoomTypeVisible;//true

            //// display entry selected text value
            //FloorProp.RoomType = RoomTypeList[index].name;
            //FloorData.hostelRoomTypeId = RoomTypeList[index].id;
            //OnPropertyChanged("FloorProp");
        }

        #region CallbackEvent
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
            if (index == 1)
            {
                //Area Load Failed
            }
            else if (index == 2)
            {
                //Hostel Load Failed
            }
            else if (index == 3)
            {
                //Block Load Failed
            }
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

        public async Task PostFloorSuccess(string resultHostel)
        {
            FloorProp.AreaName = string.Empty;
            FloorProp.HostelName = string.Empty;
            FloorProp.BlockName = string.Empty;
            FloorData.floorName = string.Empty;
            FloorData.noOfRooms = string.Empty;
            await App.Current.MainPage.DisplayAlert("", resultHostel, "OK");
            OnPropertyChanged("FloorData");
            OnPropertyChanged("FloorProp");
        }
        #endregion

    }
}
