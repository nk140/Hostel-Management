using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface FasilityI
    {
        Task ServiceFaild(string result);
        Task PostFasilitySuccess(string resultHostel);
    }
}
