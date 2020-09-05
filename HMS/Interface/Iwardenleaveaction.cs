using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Iwardenleaveaction
    {
        void GetStudentLeaveDetail(ObservableCollection<ParentStudentLeaveStatus> parent);
    }
}
