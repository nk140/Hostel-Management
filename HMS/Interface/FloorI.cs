using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface FloorI
    {
        Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes);
        Task ServiceFaild(string result);
        Task PostFloorSuccess(string resultHostel);
    }
}
