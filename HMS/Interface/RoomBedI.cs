using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RoomBedI
    {
        Task LoadAreaList(ObservableCollection<AreaModel> AreaList);
        Task LoadHostelList(ObservableCollection<HostelModel> HostelList);
        Task SaveRoomBedSuccess(string result);
        Task Failer(int index);

    }
}
