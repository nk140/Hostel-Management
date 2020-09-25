using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface BlockI
    {
        Task ServiceFaild(string result);
        Task PostBlockNameSuccess(string resultBlock);
    }
    public interface EditBlockI
    {
        void ServiceFaild(string result);
        void PostBlockNameSuccess(string resultBlock);
    }
    public interface DeleteBlockI
    {
        void ServiceFaild(string result);
        void DeleteBlockSucess(string resultBlock);
    }
}
