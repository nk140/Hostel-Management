using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class EditHostelVM : BaseViewModel, MasterI, EditHostelI
    {
        MasterServices web;
        UpdateHostel updateHostel;
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        private HostelModel hostelModel = new HostelModel();
        private string areaids;
        public string AreaIds
        {
            get
            {
                return areaids;
            }
            set
            {
                areaids = value;
                OnPropertyChanged("AreaIds");
            }
        }
        public ObservableCollection<AreaModel> AreaLists
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaList"); }
        }
        public HostelModel HostelModel
        {
            get
            {
                return hostelModel;
            }
            set
            {
                hostelModel = value;
                OnPropertyChanged("HostelModel");
            }
        }
        public ICommand UpdateHostelCommand => new Command(OnUpdateHostelCommand);
        bool _check1;
        public bool IsCheck1 { get { return _check1; } set { if (_check1 != value) { _check1 = value; OnPropertyChanged(); } } }
        bool _check2;
        public bool IsCheck2 { get { return _check2; } set { if (_check2 != value) { _check2 = value; OnPropertyChanged(); } } }
        public Command Check1Clicked { get; set; }
        public Command Check2Clicked { get; set; }
        public EditHostelVM(string hostelid,string hostelname,string areaid,string zipcode,string address,string phone,string email,string genderhostel)
        {
            //IsCheck1 = true;
            HostelModel.id = hostelid;
            HostelModel.hostelName = hostelname;
            HostelModel.areaId = areaid;
            HostelModel.zipCode = zipcode;
            HostelModel.addressLine1 = address;
            HostelModel.phoneNo = phone;
            HostelModel.email = email;
            HostelModel.hostelForGender = genderhostel;
            if (HostelModel.hostelForGender == "Female")
                IsCheck2 = true;
            else
                IsCheck1 = true;
            updateHostel = new UpdateHostel();
            AreaIds = areaid;
            Check1Clicked = new Command(check1Clicked);
            Check2Clicked = new Command(check2Clicked);
            web = new MasterServices((MasterI)this, (EditHostelI)this);
            web.GetAllArea();
        }
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
        public async void OnUpdateHostelCommand()
        {
            try
            {
                if (IsCheck1 == true)
                {
                    HostelModel.hostelForGender = "Male";
                }
                else
                {
                    HostelModel.hostelForGender = "Female";
                }
                if(validate())
                {
                    updateHostel.userId = App.userid;
                    updateHostel.hostelId = HostelModel.id;
                    updateHostel.hostelName = HostelModel.hostelName;
                    updateHostel.phone = HostelModel.phoneNo;
                    updateHostel.email = HostelModel.email;
                    updateHostel.addressLine1 = HostelModel.addressLine1;
                    updateHostel.zipCode = HostelModel.zipCode;
                    updateHostel.hostelForGender = HostelModel.hostelForGender;
                    updateHostel.areaId = AreaIds;
                    web.UpdateHostel(updateHostel);
                }
            }
            catch (Exception ex)
            {

            }
        }
        bool validate()
        {
            string emailpattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex emailRegx = new Regex(emailpattern);
            if (string.IsNullOrEmpty(HostelModel.hostelName) || HostelModel.hostelName.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Hostel Name required", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(HostelModel.phoneNo) || HostelModel.phoneNo.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Phone No required", "OK");
                return false;
            }
            else if (HostelModel.phoneNo.Length != 10)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Phone No should be 10 digit", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(HostelModel.hostelForGender) || HostelModel.hostelForGender.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Gender required", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(HostelModel.email) || HostelModel.email.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Email required", "OK");
                return false;
            }
            else if (emailRegx.IsMatch(HostelModel.email) == false)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Enter Valid Email Address", "OK");
                return false;
            }
            else if(string.IsNullOrEmpty(HostelModel.addressLine1)|| HostelModel.addressLine1.Length==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Address is required", "OK");
                return false;
            }
            else if(string.IsNullOrEmpty(HostelModel.zipCode) || HostelModel.zipCode.Length==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Zipcode is required", "OK");
                return false;
            }
            else if(HostelModel.zipCode.Length!=6)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Zipcode should br 6 digits.", "OK");
                return false;
            }
            return true;
        }
        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaList");
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

        public async void PostHostelNameSuccess(string resultHostel)
        {
            updateHostel = new UpdateHostel();
            HostelModel = new HostelModel();
            await App.Current.MainPage.DisplayAlert("HMS", resultHostel, "OK");
            OnPropertyChanged("updateHostel");
            OnPropertyChanged("HostelModel");
        }

        public async void ServiceFaild(string responseresult)
        {
            await App.Current.MainPage.DisplayAlert("HMS", responseresult, "OK");
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
