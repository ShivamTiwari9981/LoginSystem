using LoginSystemAPI.Model;
using System.Data;

namespace LoginSystemAPI.Service
{
    public interface IUserService
    {
        DataSet AddUser(UserViewModel model);
        LoginSessionModel AuthenticateUser(LoginViewModel model);
        bool SignUpUser(UserViewModel model);
        ResponseModel GetAllModule(string userType);
    }
}
