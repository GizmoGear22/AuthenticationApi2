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

    }
}
