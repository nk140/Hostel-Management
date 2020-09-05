using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RoomI
    {
        Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes);
        Task ServiceFaild(string result);
        Task PostRoomSuccess(string resultHostel);
    }
}
