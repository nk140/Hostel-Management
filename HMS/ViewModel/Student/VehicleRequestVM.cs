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
    public class FeedBackSubmissionVM : BaseViewModel, Iviewservicestatus, Isubmitfeedback
    {
        WardenService warden;
        StudentService studentService;
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
        private ObservableCollection<ViewRequestedServiceStatusModel> viewRequestedServiceStatusModels = new ObservableCollection<ViewRequestedServiceStatusModel>();
        public ObservableCollection<ViewRequestedServiceStatusModel> ViewRequestedServiceStatusModels
        {
            get
            {
                return viewRequestedServiceStatusModels;
            }
            set
            {
                viewRequestedServiceStatusModels = value;
                OnPropertyChanged("ViewRequestedServiceStatusModels");
            }
        }
        private string servicename;
        public string ServiceName
        {
            get
            {
                return servicename;
            }
            set
            {
                servicename = value;
                OnPropertyChanged("ServiceName");
            }
        }
        public ICommand SubmitFeedbackCommand => new Command(OnSubmitFeedbackCommand);
        public FeedBackSubmissionVM()
        {
            FeedbackDetailsByStudent.studentId = SecureStorage.GetAsync("userId").GetAwaiter().GetResult();
            warden = new WardenService(this);
            studentService = new StudentService(this);
            studentService.GetRequestedServiceStatus(App.userid);
        }
        public async void OnSubmitFeedbackCommand()
        {
            if (string.IsNullOrEmpty(ServiceName) || ServiceName.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Service name required", "OK");
            else if (string.IsNullOrEmpty(FeedbackDetailsByStudent.personRating) || FeedbackDetailsByStudent.personRating.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Service rating is required", "OK");
            else if (string.IsNullOrEmpty(FeedbackDetailsByStudent.improveService) || FeedbackDetailsByStudent.improveService.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Feedback description required", "OK");
            else
            {
                warden.FeedBackOnServiceByStudent(FeedbackDetailsByStudent);
            }
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

        public void LoadServicestatus(ObservableCollection<ViewRequestedServiceStatusModel> viewRequestedServiceStatusModels)
        {
            foreach (var items in viewRequestedServiceStatusModels)
            {
                if (items.personName != null || items.personMobileNo != null || items.personJob != null)
                {
                    ViewRequestedServiceStatusModels = viewRequestedServiceStatusModels;
                    FeedbackDetailsByStudent.personName = items.personName;
                    FeedbackDetailsByStudent.personMobileNo = items.personMobileNo;
                    ServiceName = items.personJob;
                    FeedbackDetailsByStudent.serviceTypeId = items.serviceTypeId;
                    OnPropertyChanged("ViewRequestedServiceStatusModels");
                    OnPropertyChanged("ServiceName");
                    OnPropertyChanged("FeedbackDetailsByStudent");
                }
            }
        }
    }
}
