using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RoomI
    {
        Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes);
        Task ServiceFaild(string result);
        void NoListFound(string result);
        Task PostRoomSuccess(string resultHostel);
    }
    public interface RoomListI
    {
        void LoadRoomList(ObservableCollection<RoomNameList> roomLists);
        void ServiceFaild(string result);
        void NoListFound(string result);
       // Task PostRoomSuccess(string resultHostel);
    }
    public interface EditRoomI
    {
        //Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes);
        void ServiceFaild(string result);
        void EditRoomSucess(string resultHostel);
    }
    public interface DeleteRoomI
    {
        //Task LoadRoomType(ObservableCollection<RoomTypeModel> RoomTypes);
        void ServiceFaild(string result);
        void DeleteRoomSucess(string resultHostel);
    }
}
