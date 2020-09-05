using HMS.Models;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface ProfileI
    {
        void LoadStudentProfile(StudentProfileModel profiles);
        Task ServiceFaild();
    }
}
