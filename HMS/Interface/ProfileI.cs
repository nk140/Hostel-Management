using HMS.Models;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface ProfileI
    {
        void LoadStudentProfile(StudentProfileModel profiles);
        Task ServiceFaild();
        void UpdatedSucessfully(string result);
    }
    public interface Iupdatestudentpassword
    {
        void ServiceFaild(string result);
        void UpdatedSucessfully(string result);
    }
}
