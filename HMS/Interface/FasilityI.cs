using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface FasilityI
    {
        Task ServiceFaild(string result);
        Task PostFasilitySuccess(string resultHostel);
    }
    public interface ViewFacilityI
    {
        void LoadFacilityList(ObservableCollection<ViewFacility> viewFacilities);
        void ServiceFaild(string result);
    }
    public interface EditFasilityI
    {
        void ServiceFaild(string result);
        void PostFasilitySuccess(string resultHostel);
    }
    public interface DeleteFasilityI
    {
        void ServiceFaild(string result);
        void PostFasilitySuccess(string resultHostel);
    }
}
