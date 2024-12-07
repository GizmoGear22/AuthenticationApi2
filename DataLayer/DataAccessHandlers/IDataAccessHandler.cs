using Models;

namespace DataLayer.DataAccessHandlers
{
    public interface IDataAccessHandler
    {
        Task AddUserToRepo(LoginModel login);
        Task<LoginModel> SearchRepoByName(UserLoginModel model);
    }
}