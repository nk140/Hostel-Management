using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface BlockI
    {
        Task ServiceFaild(string result);
        Task PostBlockNameSuccess(string resultBlock);
    }
}
