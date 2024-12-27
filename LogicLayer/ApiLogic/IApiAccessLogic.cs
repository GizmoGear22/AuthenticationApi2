using Microsoft.AspNetCore.Http;
using Models;

namespace LogicLayer.ApiLogic
{
    public interface IApiAccessLogic
    {
        Task AddUser(NewUserModel model);
        Task<bool> CheckUserCredentials(UserLoginModel model);
        Task<LoginModel> UserLogin(UserLoginModel model);
        Task<List<LoginModel>> GetAllUsers();
        Task DeleteUserById(int id);
    }
}