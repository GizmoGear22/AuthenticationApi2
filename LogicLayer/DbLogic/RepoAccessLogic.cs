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
        private RepoAccessLogic(IDataAccessHandler handler)
        {
            _handler = handler;
        }
        public async Task AddUserToRepo(LoginModel model)
        {
            await _handler.AddUserToRepo(model);
        }
    }
}
