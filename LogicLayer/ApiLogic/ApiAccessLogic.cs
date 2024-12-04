using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DbLogic;
using Models;

namespace LogicLayer.ApiLogic
{
    public class ApiAccessLogic : IApiAccessLogic
    {
        private readonly IRepoAccessLogic _handler;

        public ApiAccessLogic(IRepoAccessLogic handler)
        {
            _handler = handler;
        }

        public async Task AddUser(NewUserModel model)
        {
            LoginModel loginModel = new LoginModel();
            await _handler.AddUserToRepo(loginModel);
        }
    }
}
