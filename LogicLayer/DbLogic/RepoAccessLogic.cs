using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataAccessHandlers;
using Models;

namespace LogicLayer.DbLogic
{
    public class RepoAccessLogic : IRepoAccessLogic
    {
        private readonly IDataAccessHandler _handler;
        public RepoAccessLogic(IDataAccessHandler handler)
        {
            _handler = handler;
        }
        public async Task AddUserToRepo(LoginModel model)
        {
            await _handler.AddUserToRepo(model);
        }

        public async Task<LoginModel> FindUserByName(UserLoginModel model)
        {
            var user = await _handler.SearchRepoByName(model.Username);
            return user;
        }

        public async Task<LoginModel> FindUserById(LoginModel model)
        {
            var user = await _handler.SearchRepoById(model.Id);
            return user;
        }

        public async Task<LoginModel> FindUserById(int id)
        {
            var user = await _handler.SearchRepoById(id);
            return user;
        }

        public async Task<List<LoginModel>> GetAllUsersFromRepo()
        {
            var users = await _handler.RetrieveAllUsersFromRepo();
            return users;
        }

        public async Task DeleteUserFromRepo(LoginModel user)
        {
            _handler.RemoveUserFromRepo(user);
        }

    }
}
