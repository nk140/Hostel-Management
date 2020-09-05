using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface ServiceCategoryI
    {
        Task ServiceFaild(string result);

        Task PostServiceCategorySuccess(string result);
    }
}
