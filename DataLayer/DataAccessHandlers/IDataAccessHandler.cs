using Models;

namespace DataLayer.DataAccessHandlers
{
    public interface IDataAccessHandler
    {
        Task AddUserToRepo(LoginModel login);
        Task<LoginModel> SearchRepoByName(string userName);
        Task<LoginModel> SearchRepoById(int id);
        Task RemoveUserFromRepo(LoginModel user);
        Task<List<LoginModel>> RetrieveAllUsersFromRepo();
    }
}