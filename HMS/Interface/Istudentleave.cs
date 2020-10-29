using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Istudentleave
    {
        void GetStudentLeaveHistory(ObservableCollection<StudentLeaveHistory> studentleavedata);
        void wardenaction(string result);
        void failer(string result);
    }
    public interface Iviewservicestatus
    {
        void LoadServicestatus(ObservableCollection<ViewRequestedServiceStatusModel> viewRequestedServiceStatusModels);
        void failer(string result);
    }
    public interface ViewLeaveStatus
    {
        void GetLeavestatus(ObservableCollection<ViewLeaveStatusModel> viewLeaveStatusModels);
        void failer(string result);
    }
}
