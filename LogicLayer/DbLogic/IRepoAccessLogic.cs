using Models;

namespace LogicLayer.DbLogic
{
    public interface IRepoAccessLogic
    {
        Task AddUserToRepo(LoginModel model);
        Task<LoginModel> FindUserByName(UserLoginModel model);
        Task<LoginModel> FindUserById(LoginModel model);
        Task<LoginModel> FindUserById(int id);
        Task<List<LoginModel>> GetAllUsersFromRepo();
        Task DeleteUserFromRepo(LoginModel model);
    }
}