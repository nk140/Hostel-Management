using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class HostelVM : BaseViewModel, MasterI, HostelI
    {
        public HostelVM()
        {
            AreaVisible = false;
            IsCheck1 = true;
            Check1Clicked = new Command(check1Clicked);
            Check2Clicked = new Command(check2Clicked);
            web = new MasterServices((MasterI)this, (HostelI)this);
            // send id into base 64 formate
            web.GetAllArea();
        }


        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        private bool areaVisible;
        private long areaHeight;
        private bool hostelVisible;
        private long hostelHeight;
        private string AreaName_;
        private string HostelName_;
        private string AreaId_;
        private string HostelGender_;
        private string Address_;
        private string Zipcode_;
        private string Phone_;
        private string Email_;
        private HostelModel hostelAvailableTo_ = new HostelModel();
        MasterServices web;


        private void check2Clicked()
        {
            if (IsCheck2 == true)
            {
                IsCheck1 = false;
            }
            else
            {
                IsCheck1 = true;
            }

        }

        private void check1Clicked()
        {
            if (IsCheck1 == true)
            {

                IsCheck2 = false;
            }
            else
            {
                IsCheck2 = true;
            }
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
        public string AreaId
        {
            get { return AreaId_; }
            set { AreaId_ = value; OnPropertyChanged("AreaId"); }
        }
        public string HostelGender
        {
            get { return HostelGender_; }
            set { HostelGender_ = value; OnPropertyChanged("HostelGender"); }
        }
        public string Address
        {
            get { return Address_; }
            set { Address_ = value; OnPropertyChanged("Address"); }
        }
        public string Zipcode
        {
            get { return Zipcode_; }
            set { Zipcode_ = value; OnPropertyChanged("Zipcode"); }
        }
        public string Phone
        {
            get { return Phone_; }
            set { Phone_ = value; OnPropertyChanged("Phone"); }
        }
        public string Email
        {
            get { return Email_; }
            set { Email_ = value; OnPropertyChanged("Email"); }
        }
        public bool AreaVisible
        {
            get { return areaVisible; }
            set { areaVisible = value; OnPropertyChanged("AreaVisible"); }
        }
        public bool HostelVisible
        {
            get { return hostelVisible; }
            set { hostelVisible = value; OnPropertyChanged("HostelVisible"); }
        }
        public long AreaHeight
        {
            get { return areaHeight; }
            set { areaHeight = value; OnPropertyChanged("AreaHeight"); }
        }
        public long HostelHeight
        {
            get { return hostelHeight; }
            set { hostelHeight = value; OnPropertyChanged("HostelHeight"); }
        }

        public HostelModel Hostel
        {
            get { return hostelAvailableTo_; }
            set { hostelAvailableTo_ = value; OnPropertyChanged("Hostel"); }

        }
        public ObservableCollection<AreaModel> AreaList
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaList"); }
        }
        public ObservableCollection<HostelModel> HostelList
        {
            get { return hostelPresentmodels_; }
            set { hostelPresentmodels_ = value; OnPropertyChanged("HostelList"); }
        }
        bool _check1;
        public bool IsCheck1 { get { return _check1; } set { if (_check1 != value) { _check1 = value; OnPropertyChanged(); } } }
        bool _check2;
        public bool IsCheck2 { get { return _check2; } set { if (_check2 != value) { _check2 = value; OnPropertyChanged(); } } }
        #region commands
        public Command Check1Clicked { get; set; }
        public Command Check2Clicked { get; set; }
        #endregion
        public Command SetAreaVisibility
        {
            get
            {

                return new Command(() =>
                {
                    if (AreaList != null)
                    {
                        if (AreaList.Count == 0)
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Area", "OK");
                            AreaVisible = false;
                        }
                        else
                        {
                            AreaHeight = (40 * AreaList.Count) + 20;
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
        public Command SaveCommand
        {
            get
            {
                return new Command(() => { SaveAsync(); });
            }
        }
        public void SaveAsync()
        {
            string emailpattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex emailRegx = new Regex(emailpattern);
            if (IsCheck1 == true)
            {
                HostelGender = "Male";
            }
            else
            {
                HostelGender = "Female";
            }
            //  Hostel.hostelName = HostelName;
            if (AreaId == null)
            {
                App.Current.MainPage.DisplayAlert("", "Please Select Area", "OK");
            }
            else if (HostelName == null || HostelName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", "Please Enter Hostel Name", "OK");
            }
            else if (emailRegx.IsMatch(Email) == false)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Valid Email Address", "OK");
                return;
            }

            else
            {
                HostelModel Hostels = new HostelModel();
                Hostels.hostelName = HostelName;
                Hostels.areaId = AreaId;
                Hostels.hostelForGender = HostelGender;
                Hostels.addressLine1 = Address;
                Hostels.zipCode = Zipcode;
                Hostels.phone = Phone;
                Hostels.email = Email;
                web.SaveHostelEntry(Hostels);
                // new CountryReportService((AreaEntryI)this).SaveAreaEntry(Area);
            }
        }


        public void AreaSelection(int index)
        {
            AreaVisible = !AreaVisible;//true

            // display entry selected text value
            AreaName = AreaList[index].areaName;
            // Hostel.areaId = AreaList[index].id;
            AreaId = AreaList[index].id;
            OnPropertyChanged("AreaName");

            //selected value defined by index then move to next url to display
            //web.RequestStateList(CountryModel[index]);

        }

        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList_)
        {
            this.AreaList = new ObservableCollection<AreaModel>();
            this.AreaList = AreaList_;
            OnPropertyChanged("AreaList");
        }

        public Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            throw new NotImplementedException();
        }

        public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            throw new NotImplementedException();
        }

        public Task LoadFloorList(ObservableCollection<FloorModel> FloorList)
        {
            throw new NotImplementedException();
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public async Task ServiceFailed(int index)
        {

        }


        public async Task PostHostelNameSuccess(string resultHostel)
        {
            AreaName = null;
            HostelName = null;
            if (IsCheck2 == true)
            {
                IsCheck2 = false;
                IsCheck1 = true;
            }
            Address = null;
            Zipcode = null;
            Phone = null;
            Email = null;
            await App.Current.MainPage.DisplayAlert("", "New Hostel Detail Saved Sucessfully.", "OK");
        }

        public async Task ServiceFaild(string responseresult)
        {
            await App.Current.MainPage.DisplayAlert("", responseresult, "OK");
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }
}
