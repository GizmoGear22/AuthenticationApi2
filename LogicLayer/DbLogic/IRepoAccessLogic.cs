using Models;

namespace LogicLayer.DbLogic
{
    public interface IRepoAccessLogic
    {
        Task AddUserToRepo(LoginModel model);
        Task<LoginModel> FindUserByName(UserLoginModel model);
    }
}