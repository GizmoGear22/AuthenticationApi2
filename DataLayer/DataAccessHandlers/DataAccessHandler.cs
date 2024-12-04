using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DatabaseAccess;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataLayer.DataAccessHandlers
{
    public class DataAccessHandler : IDataAccessHandler
    {
        private readonly DBAccess _dbAccess;
        public DataAccessHandler(DBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public async Task AddUserToRepo(LoginModel login)
        {
            await _dbAccess.LoginCredentials.AddAsync(login);
            await _dbAccess.SaveChangesAsync();
        }
    }
}
