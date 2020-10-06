using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface HostelI
    {
        Task ServiceFaild(string responseresult);
        Task PostHostelNameSuccess(string resultHostel);
    }
    public interface HostelAdmissionI
    {
        void Sucess(string result);
        void failed(string result);
    }
    public interface ViewHostelAdmittedStudent
    {
        void LoadHostelStudent(ObservableCollection<HostelAdmittedStudentDetails> hostelAdmittedStudentDetails);
        void servicefailed(string result);
    }
    public interface EditHostelI
    {
        void ServiceFaild(string responseresult);
        void PostHostelNameSuccess(string resultHostel);
    }
    public interface DeleteHostelI
    {
        void ServiceFaild(string responseresult);
        void DeleteHostelNameSuccess(string resultHostel);
    }
}
