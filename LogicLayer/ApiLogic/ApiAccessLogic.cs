using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using FluentValidation.Results;
using LogicLayer.DbLogic;
using Models;
using ValidationLayer;

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

            List<string> errors = new List<string>();   

            NewUserValidation validator = new NewUserValidation();
            var results = validator.Validate(model);

            if (results.IsValid == true)
            {
                loginModel.Id = model.Id;
                loginModel.Name = model.Name;
                loginModel.Email = model.Email;
                loginModel.Password = model.Password;
                loginModel.Role = model.Role;

                await _handler.AddUserToRepo(loginModel);
            } else
            {
                foreach (var error in results.Errors)
                {
                    errors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                }

            }







        }
    }
}
