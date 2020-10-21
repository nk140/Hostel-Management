using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class VehicleRequestVM : BaseViewModel
    {
        private VehicleRequestByStudent vehicleRequestByStudent = new VehicleRequestByStudent();
        public VehicleRequestByStudent VehicleRequestByStudent
        {
            get
            {
                return vehicleRequestByStudent;
            }
            set
            {
                vehicleRequestByStudent = value;
                OnPropertyChanged("VehicleRequestByStudent");
            }
        }
        bool _check1;
        public bool IsCheck1 { get { return _check1; } set { if (_check1 != value) { _check1 = value; OnPropertyChanged(); } } }
        bool _check2;
        public bool IsCheck2 { get { return _check2; } set { if (_check2 != value) { _check2 = value; OnPropertyChanged(); } } }
        #region commands
        public Command Check1Clicked { get; set; }
        public Command Check2Clicked { get; set; }
        public ICommand RequestVehicleCommand => new Command(OnRequestVehicleCommand);
        #endregion
        public VehicleRequestVM()
        {
            VehicleRequestByStudent.studentName = SecureStorage.GetAsync("studentName").GetAwaiter().GetResult();
            VehicleRequestByStudent.studentId = SecureStorage.GetAsync("userId").GetAwaiter().GetResult();
            VehicleRequestByStudent.mobileNo = SecureStorage.GetAsync("mobileNo").GetAwaiter().GetResult();
            IsCheck1 = true;
            Check1Clicked = new Command(check1Clicked);
            Check2Clicked = new Command(check2Clicked);
        }
        private void check2Clicked()
        {
            if (IsCheck2 == true)
                IsCheck1 = false;
            else
                IsCheck1 = true;
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
        public async void OnRequestVehicleCommand()
        {
            if (IsCheck1 == true)
            {
                VehicleRequestByStudent.requestedtype = "Drop request";
            }
            else
            {
                VehicleRequestByStudent.requestedtype = "Pick-up request";
            }
            if (string.IsNullOrEmpty(VehicleRequestByStudent.sourcelocation) || VehicleRequestByStudent.sourcelocation.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Source Location Required", "OK");
            else if (string.IsNullOrEmpty(VehicleRequestByStudent.destinationlocation) || VehicleRequestByStudent.destinationlocation.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Destination Location Required", "OK");
            else if (string.IsNullOrEmpty(VehicleRequestByStudent.requestedtype) || VehicleRequestByStudent.requestedtype.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Request type required", "OK");
            else
            {

            }
        }
    }
    public class FeedBackSubmissionVM : BaseViewModel, Iservicewarden, Isubmitfeedback
    {
        WardenService warden;
        private FeedbackDetailsByStudent feedbackDetails = new FeedbackDetailsByStudent();
        public FeedbackDetailsByStudent FeedbackDetailsByStudent
        {
            get
            {
                return feedbackDetails;
            }
            set
            {
                feedbackDetails = value;
                OnPropertyChanged("FeedbackDetailsByStudent");
            }
        }
        private ObservableCollection<WardenServiceModel> servicelists = new ObservableCollection<WardenServiceModel>();
        public ObservableCollection<WardenServiceModel> WardenServiceData
        {
            get
            {
                return servicelists;
            }
            set
            {
                servicelists = value;
                OnPropertyChanged();
            }
        }
        public ICommand SubmitFeedbackCommand => new Command(OnSubmitFeedbackCommand);
        public FeedBackSubmissionVM()
        {
            FeedbackDetailsByStudent.studentName = SecureStorage.GetAsync("studentName").GetAwaiter().GetResult();
            FeedbackDetailsByStudent.studentId = SecureStorage.GetAsync("userId").GetAwaiter().GetResult();
            FeedbackDetailsByStudent.mobileNo = SecureStorage.GetAsync("mobileNo").GetAwaiter().GetResult();
            warden = new WardenService((Iservicewarden)this, (Isubmitfeedback)this);
            warden.GetServicelist();
        }
        public async void OnSubmitFeedbackCommand()
        {
            if (string.IsNullOrEmpty(FeedbackDetailsByStudent.serviceid) || FeedbackDetailsByStudent.serviceid.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Service name required", "OK");
            else if (string.IsNullOrEmpty(FeedbackDetailsByStudent.servicerating) || FeedbackDetailsByStudent.servicerating.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Service rating is required", "OK");
            else if (string.IsNullOrEmpty(FeedbackDetailsByStudent.description) || FeedbackDetailsByStudent.description.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Feedback description required", "OK");
            else
            {

            }
        }

        public void GetServicelist(ObservableCollection<WardenServiceModel> servicelists)
        {
            WardenServiceData = servicelists;
            OnPropertyChanged("WardenServiceData");
        }

        public void Servicefailed(string result)
        {

        }

        public async void sucess(string result)
        {
            FeedbackDetailsByStudent = new FeedbackDetailsByStudent();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("FeedbackDetailsByStudent");
        }

        public async void failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
