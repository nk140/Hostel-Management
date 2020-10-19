using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.Utils;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class LeaveRequestVM : BaseViewModel, StudentLeaveRequestI, ViewHostelAdmittedStudent
    {
        public LeaveRequestVM()
        {

            web = new StudentService((ViewHostelAdmittedStudent)this, (StudentLeaveRequestI)this);
            web.GetAllLeaveType();
            web.GetHostelStudent();
        }
        StudentService web;
        private ObservableCollection<LeaveTypeModel> leaveTypeModel_ = new ObservableCollection<LeaveTypeModel>();

        LeaveRequestModel LeaveRequest_ = new LeaveRequestModel();

        long typeHeight_;
        bool TypeVisible_;

        string leaveType_ = "", reason_ = "", academicyear = "", leavetypeid;

        public string StartDate, EndDate, StartTime, EndTime;

        public ObservableCollection<LeaveTypeModel> LeaveTypeList
        {
            get { return leaveTypeModel_; }
            set { leaveTypeModel_ = value; OnPropertyChanged("LeaveTypeList"); }
        }

        public LeaveRequestModel LeaveRequest
        {
            get { return LeaveRequest_; }
            set { LeaveRequest_ = value; OnPropertyChanged("LeaveRequest"); }
        }

        public string LeaveType
        {
            get { return leaveType_; }
            set { leaveType_ = value; OnPropertyChanged("LeaveType"); }
        }

        public string Reason
        {
            get { return reason_; }
            set { reason_ = value; OnPropertyChanged("Reason"); }
        }
        public string LeaveTypeId
        {
            get
            {
                return leavetypeid;
            }
            set
            {
                leavetypeid = value;
                OnPropertyChanged();
            }
        }
        public string Academicyear
        {
            get
            {
                return academicyear;
            }
            set
            {
                academicyear = value;
                OnPropertyChanged();
            }
        }
        private string hosteladmissionid;
        public string HosteladmissionId
        {
            get
            {
                return hosteladmissionid;
            }
            set
            {
                hosteladmissionid = value;
                OnPropertyChanged("HosteladmissionId");
            }
        }
        public long TypeHeight
        {
            get { return typeHeight_; }
            set { typeHeight_ = value; OnPropertyChanged("TypeHeight"); }
        }

        public bool TypeVisible
        {
            get { return TypeVisible_; }
            set { TypeVisible_ = value; OnPropertyChanged("TypeVisible"); }
        }

        public void TypeSelection(int index)
        {
            TypeVisible = !TypeVisible;//true

            // display entry selected text value
            LeaveType = LeaveTypeList[index].name;
            LeaveRequest.hostelLeaveTypeId = LeaveTypeList[index].leaveTypeId;

            OnPropertyChanged("CountryName");
        }
        private ObservableCollection<HostelAdmittedStudentDetails> hostelAdmittedStudentDetails = new ObservableCollection<HostelAdmittedStudentDetails>();
        public ObservableCollection<HostelAdmittedStudentDetails> HostelAdmittedStudentDetails
        {
            get
            {
                return hostelAdmittedStudentDetails;
            }
            set
            {
                hostelAdmittedStudentDetails = value;
                OnPropertyChanged("HostelAdmittedStudentDetails");
            }
        }
        public Command SetTypeVisibility
        {
            get
            {
                return new Command(() =>
                {
                    if (LeaveTypeList != null)
                    {
                        if (LeaveTypeList.Count > 0)
                        {
                            TypeHeight = (40 * LeaveTypeList.Count) + 20;
                            TypeVisible = !TypeVisible;
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("", "There is no Leave Type", "OK");
                            TypeVisible = false;
                        }
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "There is no Leave Type", "OK");
                        TypeVisible = false;
                    }
                });
            }
        }

        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (LeaveType.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Please Enter Leave Type", "OK");
                    }
                    else if (Reason.Length == 0 || string.IsNullOrEmpty(Reason))
                    {
                        App.Current.MainPage.DisplayAlert("", "Please Enter Reason", "OK");
                    }
                    else if (string.IsNullOrEmpty(LeaveTypeId) || LeaveTypeId.Length == 0)
                        App.Current.MainPage.DisplayAlert("HMS", "Please Enter Leave type id", "OK");
                    else if (string.IsNullOrEmpty(StartDate) || StartDate.Length == 0)
                        App.Current.MainPage.DisplayAlert("HMS", "Please enter start date", "OK");
                    else if (string.IsNullOrEmpty(EndDate) || EndDate.Length == 0)
                        App.Current.MainPage.DisplayAlert("HMS", "Please enter end date", "OK");
                    else if (string.IsNullOrEmpty(Academicyear) || Academicyear.Length == 0)
                        App.Current.MainPage.DisplayAlert("HMS", "Please enter acadmic year", "OK");
                    else if (Academicyear.Length != 4)
                        App.Current.MainPage.DisplayAlert("HMS", "year should be in 4 digit.", "OK");
                    else
                    {
                        LeaveRequest.reason = Reason;
                        LeaveRequest.remarks = Reason;
                        LeaveRequest.academicYear = Academicyear;
                        LeaveRequest.hostelAdmissionId = HosteladmissionId;
                        LeaveRequest.hostelLeaveTypeId = LeaveTypeId;
                        LeaveRequest.leaveFromDate = StartDate + "T" + "00:00:00.000Z";
                        LeaveRequest.leaveToDate = EndDate + "T" + "00:00:00.000Z";

                        web.SaveLeaveRequest(LeaveRequest);
                    }
                });
            }
        }
        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async Task GetAllLeaveType(ObservableCollection<LeaveTypeModel> leaveTypes)
        {
            LeaveTypeList = leaveTypes;
            OnPropertyChanged("LeaveTypeList");
        }

        public async Task SaveLeaveRequest(string result)
        {
            Reason = string.Empty;
            Academicyear = string.Empty;
            LeaveTypeId = string.Empty;
            StartDate = string.Empty;
            EndDate = string.Empty;
            HosteladmissionId = string.Empty;
            HostelAdmittedStudentDetails.Clear();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("HostelAdmittedStudentDetails");
            OnPropertyChanged();
        }
        public void gethosteladmissionid(string applicationno)
        {
            web.GetHostelAdmittedStudentbyappno(applicationno);
        }
        public void LoadHostelStudent(ObservableCollection<HostelAdmittedStudentDetails> hostelAdmittedStudentDetails)
        {
            if (hostelAdmittedStudentDetails.Count == 1)
            {
                HostelAdmittedStudentDetails = hostelAdmittedStudentDetails;
                OnPropertyChanged("HostelAdmittedStudentDetails");
                HosteladmissionId = HostelAdmittedStudentDetails[0].hostelAdmissionId;
                OnPropertyChanged("HosteladmissionId");
            }
        }
        public void servicefailed(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS",result, "OK");
        }
    }
}
