using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Istudentleave
    {
        void GetStudentLeaveHistory(ObservableCollection<StudentLeaveHistory> studentleavedata);
    }
}
