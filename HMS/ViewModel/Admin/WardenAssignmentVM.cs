﻿using HMS.Interface;
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
    public class WardenAssignmentVM : BaseViewModel, MasterI, ContactWardenI, IWardenAssignment
    {
        MasterServices web;
        StudentService student;
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
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
        private WardenAssignment wardenAssignment = new WardenAssignment();
        public WardenAssignment WardenAssignment
        {
            get
            {
                return wardenAssignment;
            }
            set
            {
                wardenAssignment = value;
                OnPropertyChanged("WardenAssignment");
            }
        }
        private bool islistviewvisible;
        public bool IsListviewvisible
        {
            get
            {
                return islistviewvisible;
            }
            set
            {
                islistviewvisible = value;
                OnPropertyChanged("islistviewvisible");
            }
        }
        private string selectedhostelname;
        public string SelectedHostelName
        {
            get
            {
                return selectedhostelname;
            }
            set
            {
                selectedhostelname = value;
                OnPropertyChanged("SelectedHostelName");
            }
        }
        private double listheight;
        public double Listheight
        {
            get
            {
                return listheight;
            }
            set
            {
                listheight = value;
                OnPropertyChanged("Listheight");
            }
        }
        public ICommand AssignWardenCommand => new Command(OnAssignWardenCommand);
        public WardenAssignmentVM()
        {
            web = new MasterServices((MasterI)this, (IWardenAssignment)this);
            student = new StudentService(this);
            web.GetAllArea();
            student.GetAllWarden();
        }
        public async void OnAssignWardenCommand()
        {
            if (string.IsNullOrEmpty(WardenAssignment.employeeId) || WardenAssignment.employeeId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Warden name", "OK");
            else if (string.IsNullOrEmpty(WardenAssignment.areaId) || WardenAssignment.areaId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Area Name", "OK");
            else if (string.IsNullOrEmpty(WardenAssignment.hostelId) || WardenAssignment.hostelId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Hostel Name", "OK");
            else if (string.IsNullOrEmpty(WardenAssignment.hostelAssigned) || WardenAssignment.hostelAssigned.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Hostel Name Assigned", "OK");
            else
            {
                WardenAssignment.userId = App.userid;
                web.SavewardenAssignment(WardenAssignment);
            }
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
            if (HostelList.Count != 0)
            {
                HostelModelList = HostelList;
                IsListviewvisible = true;
                Listheight = (40 * HostelModelList.Count) + 20;
                OnPropertyChanged("HostelModelList");
                OnPropertyChanged("IsListviewvisible");
                OnPropertyChanged("Listheight");
            }
        }
        public void selectedhostel(int index)
        {
            string hostelname = HostelModelList[index].hostelName;
            string hostelid = HostelModelList[index].id;
            sb.Append(hostelname);
            sb2.Append(hostelid);
            sb.Append(",");
            //sb2.Append(",");
            SelectedHostelName = sb.ToString();
            wardenAssignment.hostelId = sb2.ToString();
            wardenAssignment.hostelAssigned = SelectedHostelName;
            OnPropertyChanged("SelectedHostelName");
            OnPropertyChanged("wardenAssignment");
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

        public async void SaveWardenassignment(string result)
        {
            WardenAssignment = new WardenAssignment();
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            IsListviewvisible = false;
            SelectedHostelName = "";
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("WardenAssignment");
            OnPropertyChanged("IsListviewvisible");
            OnPropertyChanged("SelectedHostelName");
        }
        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
