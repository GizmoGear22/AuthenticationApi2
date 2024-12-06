using Microsoft.AspNetCore.Http;
using Models;

namespace LogicLayer.ApiLogic
{
    public interface IApiAccessLogic
    {
        Task AddUser(NewUserModel model);
        Task<bool> CheckLoginCredentials(UserLoginModel model);
    }
}