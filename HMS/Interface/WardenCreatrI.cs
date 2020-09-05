using HMS.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface WardenCreatrI
    {
        Task ServiceFaild();

        Task GetAllRole(ObservableCollection<RoleModel> role_);

        Task SaveWarden(String result);
    }
}
