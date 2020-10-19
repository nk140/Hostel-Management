using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class StudentHostelAdmissionVM : BaseViewModel, HostelAdmissionI, RoomBedI1, MasterI, FloorI, Icoursedetail, ProfileI
    {
        StudentService web;
        MasterServices masters;
        private HostelAdmission hostelAdmission = new HostelAdmission();
        public HostelAdmission HostelAdmission
        {
            get
            {
                return hostelAdmission;
            }
            set
            {
                hostelAdmission = value;
                OnPropertyChanged("HostelAdmission");
            }
        }
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
        private ObservableCollection<CourseDetailModel> courseDetailModels = new ObservableCollection<CourseDetailModel>();
        public ObservableCollection<CourseDetailModel> CourseDetailModels
        {
            get
            {
                return courseDetailModels;
            }
            set
            {
                courseDetailModels = value;
                OnPropertyChanged("courseDetailModels");
            }
        }
        private ObservableCollection<StudentProfileModel> studentProfile = new ObservableCollection<StudentProfileModel>();
        public ObservableCollection<StudentProfileModel> StudentProfileModel
        {
            get
            {
                return studentProfile;
            }
            set
            {
                studentProfile = value;
                OnPropertyChanged("StudentProfileModel");
            }
        }
        public StudentHostelAdmissionVM()
        {
            web = new StudentService((HostelAdmissionI)this, (Icoursedetail)this, (ProfileI)this);
            masters = new MasterServices((RoomBedI1)this, (MasterI)this, (FloorI)this);
            web.GetProfiile(App.userid);
            masters.GetAllArea();
            masters.GetAllRomType();
            web.GetCourseList();
        }
        public void GethostelList(string areaid)
        {
            masters.GetAllHostel(areaid);
        }
        public void GetRoombedlist(string hostelid)
        {
            masters.GetRoomBedList(hostelid);
        }
        public ICommand SaveHostelAdmissionCommand => new Command(OnSaveHostelAdmissionCommand);
        public async void failed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
        public async void OnSaveHostelAdmissionCommand()
        {
            if (string.IsNullOrEmpty(HostelAdmission.firstName) || HostelAdmission.firstName.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Student Name", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.courseId) || HostelAdmission.courseId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Course", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.bedId) || HostelAdmission.bedId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Bed", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.hostelId) || HostelAdmission.hostelId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Hostel", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.academicYear) || HostelAdmission.academicYear.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Academic Year", "OK");
            else if (HostelAdmission.academicYear.Length != 4)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter valid academic year", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.applicationNo) || HostelAdmission.applicationNo.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Application No", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.parentAddress) || HostelAdmission.parentAddress.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Parent Address", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.parentPhoneNo) || HostelAdmission.parentPhoneNo.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Parent Phone no", "OK");
            else if (HostelAdmission.parentPhoneNo.Length != 10)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter 10 digit Phone no", "OK");
            //else if (string.IsNullOrEmpty(HostelAdmission.roomId) || HostelAdmission.roomId.Length == 0)
            //    await App.Current.MainPage.DisplayAlert("HMS", "Room Id Required.", "OK");
            else if (string.IsNullOrEmpty(HostelAdmission.roomTypeId) || HostelAdmission.roomTypeId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Room Type ", "OK");
            else
            {
                web.SaveHostelAdmission(HostelAdmission);
            }
        }
        public async void Sucess(string result)
        {
            HostelAdmission = new HostelAdmission();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("HostelAdmission");
        }

        public void LoadRoomBedList(ObservableCollection<RoomBedData> roomBedDatas)
        {
            RoomBedDatas = roomBedDatas;
            OnPropertyChanged("RoomBedDatas");
        }

        public void Failer(string result)
        {

        }

        public void NoListFound(string result)
        {

        }

        public async Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            AreaLists = AreaList;
            OnPropertyChanged("AreaLists");
        }

        public async Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            HostelLists = HostelList;
            OnPropertyChanged("HostelLists");
        }

        public async Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {

        }

        public async Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {

        }

        public async Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {

        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }

        public async Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes)
        {
            RoomTypeModels = RoomTypes;
            OnPropertyChanged("RoomTypeModels");
        }

        public Task ServiceFaild(string result)
        {
            throw new NotImplementedException();
        }

        public Task PostRoomSuccess(string resultHostel)
        {
            throw new NotImplementedException();
        }

        public void GetCourseList(ObservableCollection<CourseDetailModel> courseDetailModels)
        {
            CourseDetailModels = courseDetailModels;
            OnPropertyChanged("CourseDetailModels");
        }

        public Task PostFloorSuccess(string resultHostel)
        {
            throw new NotImplementedException();
        }

        public void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles)
        {
            StudentProfileModel = profiles;
            foreach (var items in StudentProfileModel)
            {
                HostelAdmission.applicationNo = items.applicationNo;
                HostelAdmission.firstName = items.studentName;
                HostelAdmission.studentId = items.studentId;
            }
            if (!string.IsNullOrEmpty(HostelAdmission.applicationNo) || HostelAdmission.applicationNo.Length == 0)
                App.Current.MainPage.DisplayAlert("HMS", "You have already registered", "OK");
            OnPropertyChanged("StudentProfileModel");
            OnPropertyChanged("HostelAdmission");
        }

        public async Task ServiceFaild()
        {

        }

        public void UpdatedSucessfully(string result)
        {
            throw new NotImplementedException();
        }
    }
}
