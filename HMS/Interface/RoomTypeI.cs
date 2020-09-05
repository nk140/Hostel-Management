using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RoomTypeI
    {
        Task ServiceFaild(string result);

        Task PostRoomTypeSuccess(string result);
    }
}
