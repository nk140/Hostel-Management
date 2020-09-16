using HMS.Models;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface LoginI
    {
        void UserLoginSuccess(UserModel userData);
        void StudentLoginSucess(StudentModel studentModel);
        Task ProccessFailed();
    }
}
