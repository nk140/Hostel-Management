using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Iservicewarden
    {
        void GetServicelist(ObservableCollection<WardenServiceModel> servicelists);
        void Servicefailed(string result);
    }
    public interface Isubmitfeedback
    {
        void sucess(string result);
        void failer(string result);
    }
}
