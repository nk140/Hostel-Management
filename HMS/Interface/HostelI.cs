using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface HostelI
    {
        Task ServiceFaild(string responseresult);
        Task PostHostelNameSuccess(string resultHostel);
    }
    public interface EditHostelI
    {
        void ServiceFaild(string responseresult);
        void PostHostelNameSuccess(string resultHostel);
    }
    public interface DeleteHostelI
    {
        void ServiceFaild(string responseresult);
        void DeleteHostelNameSuccess(string resultHostel);
    }
}
