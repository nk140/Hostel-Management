using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;

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
}
