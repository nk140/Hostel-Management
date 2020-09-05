using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface AreaI
    {
        Task ServiceFaild(string result);

        Task PostAreaNameSuccess(string result);

    }
}
