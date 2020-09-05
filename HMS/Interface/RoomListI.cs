using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RoomListI
    {
        Task LoadRoomList(ObservableCollection<RoomListModel> AreaList);
        Task Failer();
    }
}
