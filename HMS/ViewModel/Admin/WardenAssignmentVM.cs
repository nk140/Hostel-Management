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
    public class WardenAssignmentVM : BaseViewModel, MasterI, ContactWardenI
    {
        MasterServices web;
        StudentService student;
        private ObservableCollection<WardenInfoModel> warden_ = new ObservableCollection<WardenInfoModel>();


        public ObservableCollection<WardenInfoModel> Warden
        {
            get { return warden_; }
            set { warden_ = value; OnPropertyChanged("Warden"); }
        }
        private ObservableCollection<AreaModel> areaPresentmodels_ = new ObservableCollection<AreaModel>();
        public ObservableCollection<AreaModel> AreaModel
        {
            get { return areaPresentmodels_; }
            set { areaPresentmodels_ = value; OnPropertyChanged("AreaModel"); }
        }
        private ObservableCollection<HostelModel> hostelPresentmodels_ = new ObservableCollection<HostelModel>();
        public ObservableCollection<HostelModel> HostelModelList
        {
            get { return hostelPresentmodels_; }
            set { hostelPresentmodels_ = value; OnPropertyChanged("HostelModelList"); }
        }
        public ICommand AssignWardenCommand => new Command(OnAssignWardenCommand);
        public WardenAssignmentVM()
        {
            web = new MasterServices(this);
            student = new StudentService(this);
            web.GetAllArea();
            student.GetAllWarden();
        }
        public async void OnAssignWardenCommand()
        {

        }
        public void GetHostelList(string areaid)
        {
            web.GetAllHostel(areaid);
        }
        public async Task GetAllWarden(ObservableCollection<WardenInfoModel> warden_)
        {
            Warden = warden_;
            OnPropertyChanged("Warden");
        }

        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaModel = AreaList;
            OnPropertyChanged("AreaModel");
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
            HostelModelList = HostelList;
            OnPropertyChanged("HostelModelList");
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public async Task ServiceFaild()
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No Data Found", "OK");
        }

        public async Task ServiceFailed(int index)
        {
            await App.Current.MainPage.DisplayAlert("HMS", "No Data Found", "OK");
        }

        public void NoListFound(string result)
        {
            throw new NotImplementedException();
        }
    }
}
