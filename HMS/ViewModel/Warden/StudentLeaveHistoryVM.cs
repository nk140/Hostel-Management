using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class StudentLeaveHistoryVM : BaseViewModel, Istudentleave
    {
        WardenService warden;
        private ObservableCollection<StudentLeaveHistory> studentleavedata = new ObservableCollection<StudentLeaveHistory>();
        #region list
        public ObservableCollection<StudentLeaveHistory> Studentleavedata
        {
            get
            {
                return studentleavedata;
            }
            set
            {
                studentleavedata = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public ICommand LeaveActionOption => new Command<StudentLeaveHistory>(OnLeaveActionOption);
        public StudentLeaveHistoryVM()
        {
            warden = new WardenService(this);
            warden.GetStudentLeaveHistory();
        }
        public async void OnLeaveActionOption(StudentLeaveHistory obj)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Choose what action you take", "Cancel", null, "Approve", "Reject");
            if (result.Equals("Approve"))
            {
                wardenstatusonleavemodel wardenstatusonleavemodel = new wardenstatusonleavemodel();
                wardenstatusonleavemodel.userId = App.userid;
                wardenstatusonleavemodel.hostelAdmissionId = obj.hostelAdmissionId;
                wardenstatusonleavemodel.leaveTypeId = obj.hostelLeaveTypeId;
                wardenstatusonleavemodel.isApproved = "Approved";
                wardenstatusonleavemodel.rejectReason = "";
                warden.ApproveStudentLeave(wardenstatusonleavemodel);
            }
            else if (result.Equals("Reject"))
            {
                wardenstatusonleavemodel wardenstatusonleavemodel = new wardenstatusonleavemodel();
                wardenstatusonleavemodel.userId = App.userid;
                wardenstatusonleavemodel.hostelAdmissionId = obj.hostelAdmissionId;
                wardenstatusonleavemodel.leaveTypeId = obj.hostelLeaveTypeId;
                wardenstatusonleavemodel.isApproved = "Reject";
                wardenstatusonleavemodel.rejectReason = "Parent Not Allowed.";
                warden.ApproveStudentLeave(wardenstatusonleavemodel);
            }
            else
            {

            }
        }
        public void GetStudentLeaveHistory(ObservableCollection<StudentLeaveHistory> studentleavedata)
        {
            Studentleavedata = new ObservableCollection<StudentLeaveHistory>();
            Studentleavedata = studentleavedata;
            OnPropertyChanged();
        }

        public void wardenaction(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void failer(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
    public class ViewStudentLeaveStatus : BaseViewModel, ViewLeaveStatus
    {
        StudentService studentService;
        private ObservableCollection<ViewLeaveStatusModel> viewLeaveStatusModels = new ObservableCollection<ViewLeaveStatusModel>();
        public ObservableCollection<ViewLeaveStatusModel> ViewLeaveStatusModels
        {
            get
            {
                return viewLeaveStatusModels;
            }
            set
            {
                viewLeaveStatusModels = value;
                OnPropertyChanged("ViewLeaveStatusModels");
            }
        }
        private bool isdataavailable;
        public bool Isdataavailable
        {
            get
            {
                return isdataavailable;
            }
            set
            {
                isdataavailable = value;
                OnPropertyChanged("Isdataavailable");
            }
        }
        public ViewStudentLeaveStatus()
        {
            studentService = new StudentService(this);
            studentService.GetLeaveStatus(App.userid);
        }
        public void failer(string result)
        {

        }
        public void GetLeavestatus(ObservableCollection<ViewLeaveStatusModel> viewLeaveStatusModels)
        {
            Isdataavailable = true;
            ViewLeaveStatusModels = viewLeaveStatusModels;
            OnPropertyChanged("ViewLeaveStatusModels");
            OnPropertyChanged("Isdataavailable");
        }
    }
    public class ViewWardLeaveHistoryVM : BaseViewModel, Iwardenleaveaction, IApproveLeave, IRejectLeave
    {
        WardenService wardenService;
        string hosteladmissionids, studentids;
        int counter;
        private ObservableCollection<ParentStudentLeaveStatus> parentStudentLeaveStatuses = new ObservableCollection<ParentStudentLeaveStatus>();
        public ObservableCollection<ParentStudentLeaveStatus> ParentStudentLeaveStatuses
        {
            get
            {
                return parentStudentLeaveStatuses;
            }
            set
            {
                parentStudentLeaveStatuses = value;
                OnPropertyChanged("ParentStudentLeaveStatuses");
            }
        }
        public ICommand LeaveActionOption => new Command<ParentStudentLeaveStatus>(OnLeaveActionOption);
        public ViewWardLeaveHistoryVM(string studentid, string hosteladmissionid)
        {
            studentids = studentid;
            hosteladmissionids = hosteladmissionid;
            wardenService = new WardenService((Iwardenleaveaction)this, (IApproveLeave)this, (IRejectLeave)this);
            wardenService.GetWardLeave(studentid);
        }
        public void GetStudentLeaveDetail(ObservableCollection<ParentStudentLeaveStatus> parent)
        {
            ParentStudentLeaveStatuses = parent;
            OnPropertyChanged("ParentStudentLeaveStatuses");
        }
        public async void OnLeaveActionOption(ParentStudentLeaveStatus obj)
        {
            LeaveStatusModel leaveStatusModel = new LeaveStatusModel();
            var result = await App.Current.MainPage.DisplayActionSheet("Choose what action you take", "Cancel", null, "Approve", "Reject");
            if (result.Equals("Approve"))
            {
                leaveStatusModel.hostelAdmissionId = hosteladmissionids;
                leaveStatusModel.leaveTypeId = obj.leaveTypeId;
                leaveStatusModel.isApproved = "Approved";
                wardenService.ApproveWardLeave(leaveStatusModel);
            }
            else if (result.Equals("Reject"))
            {
                leaveStatusModel.hostelAdmissionId = hosteladmissionids;
                leaveStatusModel.leaveTypeId = obj.leaveTypeId.ToString();
                leaveStatusModel.isApproved = "Reject";
                wardenService.ApproveWardLeave(leaveStatusModel);
            }
            else
            {

            }
        }

        public async void approved(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            wardenService.GetWardLeave(studentids);
        }

        public async void failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void reject(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
