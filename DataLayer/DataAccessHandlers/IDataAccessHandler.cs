using Models;

namespace DataLayer.DataAccessHandlers
{
    public interface IDataAccessHandler
    {
        Task AddUserToRepo(LoginModel login);
        Task<LoginModel> FindUserByName(UserLoginModel model);
    }
}