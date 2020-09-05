using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface HostelI
    {
        Task ServiceFaild(string responseresult);
        Task PostHostelNameSuccess(string resultHostel);
    }
}
