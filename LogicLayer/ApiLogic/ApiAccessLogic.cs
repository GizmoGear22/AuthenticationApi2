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
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

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

            NewUserValidation validator = new NewUserValidation();
            var results = validator.Validate(model);

            if (results.IsValid == true)
            {
                LoginModel loginModel = new LoginModel();

                loginModel.Id = model.Id;
                loginModel.Name = model.Name;
                loginModel.Email = model.Email;
                loginModel.Password = model.Password;
                loginModel.Role = model.Role;

                await _handler.AddUserToRepo(loginModel);
            } else
            {
                List<string> errors = new List<string>();
                foreach (var error in results.Errors)
                {
                    errors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                }

                await validator.ValidateAndThrowAsync(model);
            }

        }

        public async Task<bool> CheckUserCredentials(UserLoginModel model)
        {
            var user = await _handler.FindUserByName(model);
            if (user != null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
