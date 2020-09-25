using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface FasilityI
    {
        Task ServiceFaild(string result);
        Task PostFasilitySuccess(string resultHostel);
    }
    public interface EditFasilityI
    {
        void ServiceFaild(string result);
        void PostFasilitySuccess(string resultHostel);
    }
    public interface DeleteFasilityI
    {
        void ServiceFaild(string result);
        void PostFasilitySuccess(string resultHostel);
    }
}
