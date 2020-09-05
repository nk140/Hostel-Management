using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class BlockVM : BaseViewModel, MasterI, BlockI
    {
        public BlockVM()
        {
            AreaVisible = false;
            HostelVisible = false;
            BlockData = new BlockModel();
            web = new MasterServices((MasterI)this, this);
            // send id into base 64 formate
            web.GetAllArea();
            //web.GetAllHostel(AreaModelList[0]);
        }
        MasterServices web;
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        private BlockModel block_ = new BlockModel();

        private bool AreaVisible_;
        private bool HostelVisible_;
        private long AreaHeight_;
        private long HostelHeight_;
        private string AreaName_;
        private string HostelName_;
        private string Name_;

        #region AssignVariableAndObj
        #region VariableAssign

        public string AreaName
        {
            get { return AreaName_; }
            set { AreaName_ = value; OnPropertyChanged("AreaName"); }
        }
        public string HostelName
        {
            get { return HostelName_; }
            set { HostelName_ = value; OnPropertyChanged("HostelName"); }
        }
        public string Name
        {
            get { return Name_; }
            set { Name_ = value; OnPropertyChanged("Name"); }
        }
        public bool AreaVisible
        {
            get { return AreaVisible_; }
            set { AreaVisible_ = value; OnPropertyChanged(); }
        }
        public bool HostelVisible
        {
            get { return HostelVisible_; }
            set { HostelVisible_ = value; OnPropertyChanged(); }
        }
        public long AreaHeight
        {
            get { return AreaHeight_; }
            set { AreaHeight_ = value; OnPropertyChanged(); }
        }
        public long HostelHeight
        {
            get { return HostelHeight_; }
            set { HostelHeight_ = value; OnPropertyChanged(); }
        }
        #endregion

        #region AssignModelClass

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

        public BlockModel BlockData
        {
            get { return block_; }
            set { block_ = value; OnPropertyChanged("BlockData"); }
        }

        #endregion
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
                            AreaVisible = false;
                        }
                        else
                        {
                            AreaHeight = (40 * AreaModelList.Count) + 20;
                            AreaVisible = !AreaVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Area", "OK");
                        AreaVisible = false;
                    }


                    OnPropertyChanged("AreaModelList");
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
                            HostelVisible = false;
                        }
                        else
                        {
                            HostelHeight = (40 * HostelModelList.Count) + 20;
                            HostelVisible = !HostelVisible;
                        }

                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Hostel", "OK");
                        HostelVisible = false;
                    }


                    OnPropertyChanged("HostelModelList");
                });
            }
        }

        public Command SaveBlock
        {
            get
            {
                return new Command(() =>
                {
                    if (BlockData.areaId == null || BlockData.areaId.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Select Area", "OK");
                    }
                    else if (BlockData.hostelId == null || BlockData.hostelId.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Select Hoostel", "OK");
                    }
                    else if (BlockData.name == null || BlockData.name.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Enter Block Name", "OK");
                    }
                    else
                    {
                        web.SaveBlockEntry(BlockData);
                    }
                });
            }
        }

        #endregion

        public void AreaSelection(int index)
        {
            AreaVisible = !AreaVisible;//true

            // display entry selected text value
            AreaName = AreaModelList[index].areaName;
            OnPropertyChanged("AreaName");
            BlockData.areaId = AreaModelList[index].id;
            BlockData.hostelId = "";
            HostelName = "";
            OnPropertyChanged("HostelName");
            web.GetAllHostel(AreaModelList[index]);

        }

        public void HostelSelection(int index)
        {
            HostelVisible = !HostelVisible;//true

            // display entry selected text value
            HostelName = HostelModelList[index].hostelName;
            OnPropertyChanged("HostelName");

            BlockData.hostelId = HostelModelList[index].id;


        }

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

        public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            throw new NotImplementedException();
        }

        //public Task LoadFloorList(ObservableCollection<FloorModel> FloorList)
        //{
        //    throw new NotImplementedException();
        //}

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
        }

        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("", result, "OK");
        }

        public async Task PostBlockNameSuccess(string resultBlock)
        {
            BlockData.name = null;
            AreaName = string.Empty;
            HostelName = null;
            await App.Current.MainPage.DisplayAlert("", resultBlock, "OK");
            OnPropertyChanged("BlockData");
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }
    }
}
