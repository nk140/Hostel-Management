using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface MasterI
    {
        Task LoadAreaList(ObservableCollection<AreaModel> AreaList);
        Task LoadHostelList(ObservableCollection<HostelModel> HostelList);
        Task LoadBlockList(ObservableCollection<BlockModel> BlockList);
        void NoListFound(string result);
        Task LoadFloorList(ObservableCollection<FloorData> FloorList);
        Task LoadRoomList(ObservableCollection<RoomModel> RoomList);
        Task ServiceFailed(int index);

    }
}
