using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface ContactWardenI
    {
        Task ServiceFaild();

        Task GetAllWarden(ObservableCollection<WardenInfoModel> warden_);
    }
}
