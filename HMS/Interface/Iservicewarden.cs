using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface Iservicewarden
    {
        void GetServicelist(ObservableCollection<WardenServiceModel> servicelists);

    }
}
