using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.Interface
{
    public interface IHostelMaster
    {
        void GetHostelDetailList(ObservableCollection<HostalMasterModel> HostelData);
    }
}
