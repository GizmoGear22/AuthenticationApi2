using Models;

namespace DataLayer.DataAccessHandlers
{
    public interface IDataAccessHandler
    {
        Task AddUserToRepo(LoginModel login);
        Task<LoginModel> SearchRepoByName(string userName);
        Task<LoginModel> SearchRepoById(int id);
        Task RemoveUserFromRepo(int id);
        Task<List<LoginModel>> RetrieveAllUsersFromRepo();
    }
}