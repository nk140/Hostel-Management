using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface AreaI
    {
        Task ServiceFaild(string result);

        Task PostAreaNameSuccess(string result);

    }
    public interface EditAreaI
    {
        void servicefailed(string result);
        void UpdateAreaDetailSucess(string result);
    }
    public interface DeleteAreaI
    {
        void servicefailed(string result);
        void DeleteAreaSucess(string result);
    }
}
