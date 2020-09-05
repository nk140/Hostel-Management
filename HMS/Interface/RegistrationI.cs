using System;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RegistrationI
    {
        Task ServiceFaild();
        Task RegistrationSuccess(String result);
    }
}
