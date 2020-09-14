using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.Utils;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class LeaveRequestVM : BaseViewModel, StudentLeaveRequestI
    {
        public LeaveRequestVM()
        {

            web = new StudentService(this);
            web.GetAllLeaveType();

        }
        StudentService web;
        private ObservableCollection<LeaveTypeModel> leaveTypeModel_ = new ObservableCollection<LeaveTypeModel>();

        LeaveRequestModel LeaveRequest_ = new LeaveRequestModel();

        long typeHeight_;
        bool TypeVisible_;

        string leaveType_ = "", reason_ = "";

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
            LeaveRequest.hostelLeaveTypeId = LeaveTypeList[index].id;

            OnPropertyChanged("CountryName");

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
                    else if (Reason.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Please Enter Reason", "OK");
                    }
                    else
                    {
                        LeaveRequest.reason = Reason;
                        LeaveRequest.remarks = Reason;
                        LeaveRequest.hostelAdmissionId = Constants.AdmissioonId;
                        LeaveRequest.academicYear = Constants.AcadamicYear;
                        LeaveRequest.leaveFromDate = StartDate + "T" + StartTime;
                        LeaveRequest.leaveToDate = EndDate + "T" + EndTime;

                        web.SaveLeaveRequest(LeaveRequest);
                    }
                });
            }
        }

        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS",result, "OK");
        }

        public async Task GetAllLeaveType(ObservableCollection<LeaveTypeModel> leaveTypes)
        {
            LeaveTypeList = leaveTypes;
            OnPropertyChanged("LeaveTypeList");
        }

        public async Task SaveLeaveRequest(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS",result, "OK");
        }
    }
}
