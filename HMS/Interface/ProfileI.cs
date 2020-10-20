using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface ProfileI
    {
        void LoadStudentProfile(ObservableCollection<StudentProfileModel> profiles);
        void Loadwardenprofile(ObservableCollection<WardenProfileModel> wardenProfileModels);
        Task ServiceFaild();
        void UpdatedSucessfully(string result);
    }
    public interface Iupdatestudentpassword
    {
        void ServiceFaild(string result);
        void UpdatedSucessfully(string result);
    }
}
