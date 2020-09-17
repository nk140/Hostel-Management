using System;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RegistrationI
    {
        void ServiceFaild(string result);
        void RegistrationSuccess(String result);
    }
}
