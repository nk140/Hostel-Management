using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Iwardenleaveaction
    {
        void GetStudentLeaveDetail(ObservableCollection<ParentStudentLeaveStatus> parent);
    }
    public interface IApproveLeave
    {
        void approved(string result);
        void failer(string result);
    }
    public interface IRejectLeave
    {
        void reject(string result);
        void failer(string result);
    }
}
