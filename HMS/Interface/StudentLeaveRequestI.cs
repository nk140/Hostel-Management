using HMS.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface StudentLeaveRequestI
    {
        Task ServiceFaild(string result);

        Task GetAllLeaveType(ObservableCollection<LeaveTypeModel> leaveTypes);

        Task SaveLeaveRequest(String result);
    }
    public interface EditleaveType
    {
        void sucess(string result);
        void failer(string result);
    }
    public interface DeleteLeavetype
    {
        void deletesucess(string result);
        void failer(string result);
    }
}
