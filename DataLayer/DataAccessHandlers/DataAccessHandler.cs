using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DatabaseAccess;
using Microsoft.EntityFrameworkCore;
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

        public async Task<LoginModel> SearchRepoByName(string userName)
        {
            var user = await _dbAccess.LoginCredentials.Where(p => p.Name == userName).FirstOrDefaultAsync();
            if (user == null)

            { return user; }
            else
            {
                throw new Exception("User Not Found");
            }
        }

        public async Task<LoginModel> SearchRepoById(int id)
        {
            var user = await _dbAccess.LoginCredentials.Where(p => p.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task RemoveUserFromRepo(LoginModel user)
        {
            _dbAccess.LoginCredentials.Remove(user);
            await _dbAccess.SaveChangesAsync();
        }

        public async Task<List<LoginModel>> RetrieveAllUsersFromRepo()
        {
            var users = await _dbAccess.LoginCredentials.ToListAsync();
            return users;
        }
    }
}
