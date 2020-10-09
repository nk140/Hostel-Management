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
        public StudentLeaveHistoryVM()
        {
            warden = new WardenService(this);
            warden.GetStudentLeaveHistory();
        }
        public void GetStudentLeaveHistory(ObservableCollection<StudentLeaveHistory> studentleavedata)
        {
            Studentleavedata = new ObservableCollection<StudentLeaveHistory>();
            Studentleavedata = studentleavedata;
            OnPropertyChanged();
        }
    }
    public class ViewWardLeaveHistoryVM : BaseViewModel, Iwardenleaveaction,IApproveLeave,IRejectLeave
    {
        WardenService wardenService;
        string hosteladmissionids, studentids;
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
        public ViewWardLeaveHistoryVM(string studentid,string hosteladmissionid)
        {
            studentids = studentid;
            hosteladmissionids = hosteladmissionid;
            wardenService = new WardenService((Iwardenleaveaction)this,(IApproveLeave)this,(IRejectLeave)this);
            wardenService.GetWardLeave(studentid);
        }
        public void GetStudentLeaveDetail(ObservableCollection<ParentStudentLeaveStatus> parent)
        {
            ParentStudentLeaveStatuses = parent;
            OnPropertyChanged("ParentStudentLeaveStatuses");
        }
        public async void OnLeaveActionOption(ParentStudentLeaveStatus obj)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Choose what action you take", "Cancel", null, "Approve", "Reject");
            if (result.Equals("Approve"))
            {
                wardenService.ApproveWardLeave(hosteladmissionids, "Approved");
            }
            else
            {
                wardenService.ApproveWardLeave(hosteladmissionids, "Rejected");
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
