using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class RoomBedVM : BaseViewModel, RoomBedI
    {
        public RoomBedVM()
        {

            AreaVisible = false;
            HostelVisible = false;
            web = new MasterServices(this);
            web.GetAllArea1();
        }

        MasterServices web;

        private ObservableCollection<AreaModel> areamodels_ = new ObservableCollection<AreaModel>();
        private ObservableCollection<HostelModel> hostelmodels_ = new ObservableCollection<HostelModel>();
        string BedNo_ = "";
        long HostelHeight_ = 0;
        bool HostelVisible_ = false;
        long AreaHeight_ = 0;
        bool AreaVisible_ = false;
        string hostelId = "";

        string AreaName_, HostelName_;

        public bool HostelVisible
        {
            get { return HostelVisible_; }
            set { HostelVisible_ = value; OnPropertyChanged("HostelVisible"); }
        }

        public long HostelHeight
        {
            get { return HostelHeight_; }
            set { HostelHeight_ = value; OnPropertyChanged("HostelHeight"); }
        }

        public bool AreaVisible
        {
            get { return AreaVisible_; }
            set { AreaVisible_ = value; OnPropertyChanged("AreaVisible"); }
        }

        public long AreaHeight
        {
            get { return AreaHeight_; }
            set { AreaHeight_ = value; OnPropertyChanged("AreaHeight"); }
        }

        public string BedNo
        {
            get { return BedNo_; }
            set { BedNo_ = value; OnPropertyChanged("BedNo"); }
        }

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


        public ObservableCollection<AreaModel> AreaModelList
        {
            get { return areamodels_; }
            set { areamodels_ = value; OnPropertyChanged("AreaModelList"); }
        }

        public ObservableCollection<HostelModel> HostelModelList
        {
            get { return hostelmodels_; }
            set { hostelmodels_ = value; OnPropertyChanged("HostelModelList"); }
        }


        #region Command
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


                    OnPropertyChanged("AreaVisible");
                    OnPropertyChanged("AreaHeight");
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


                    OnPropertyChanged("HostelVisible");
                    OnPropertyChanged("HostelHeight");
                });
            }
        }

        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (hostelId.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("HMS", "Select Hostel ", "OK");
                    }
                    else if (BedNo.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("HMS", "Enter Bed Number", "OK");
                    }
                    else
                    {
                        web.SaveRoomBed(hostelId, BedNo);
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

            HostelName = "";
            OnPropertyChanged("AreaVisible");
            OnPropertyChanged("AreaName");
            OnPropertyChanged("HostelName");
            hostelId = "";
            web.GetAllHostel1(AreaModelList[index]);

        }

        public void HostelSelection(int index)
        {
            HostelVisible = !HostelVisible;//true

            // display entry selected text value
            HostelName = HostelModelList[index].hostelName;
            hostelId = HostelModelList[index].id;
            OnPropertyChanged("HostelVisible");
            OnPropertyChanged("HostelName");


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

        public async Task SaveRoomBedSuccess(string result)
        {
            AreaName = string.Empty;
            HostelName = string.Empty;
            BedNo = string.Empty;
            await App.Current.MainPage.DisplayAlert("", result, "OK");
        }

        public async Task Failer(int index)
        {
            await App.Current.MainPage.DisplayAlert("", "Something went wrong", "OK");
        }
    }
}
