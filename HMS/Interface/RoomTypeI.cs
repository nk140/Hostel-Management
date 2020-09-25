using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RoomTypeI
    {
        Task ServiceFaild(string result);

        Task PostRoomTypeSuccess(string result);
    }
    public interface EditRoomTypeI
    {
        void ServiceFaild(string result);
        void UpdateRoomTypeSuccess(string result);
    }
    public interface DeleteRoomTypeI
    {
        void ServiceFaild(string result);

        void DeleteRoomTypeSuccess(string result);
    }
}
