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
using Microsoft.Extensions.Logging;
using DataLayer.DataAccessHandlers;

namespace LogicLayer.ApiLogic
{
    public class ApiAccessLogic : IApiAccessLogic
    {
        private readonly IRepoAccessLogic _handler;
        private readonly ILogger<ApiAccessLogic> _logger;
        private readonly IDataAccessHandler _dataAccessHandler;

        public ApiAccessLogic(IRepoAccessLogic handler, ILogger<ApiAccessLogic> logger, IDataAccessHandler dataAccessHandler)
        {
            _handler = handler;
            _logger = logger;
            _dataAccessHandler = dataAccessHandler;
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

        public async Task<LoginModel>UserLogin(UserLoginModel model)
        {
            var user = await _handler.FindUserByName(model);
            return user;
        }

        public async Task<bool> CheckUserCredentials(UserLoginModel model)
        {
            UserLoginValidator validator = new UserLoginValidator(_dataAccessHandler);
            var results = await validator.ValidateAsync(model);

            try
            {
                if (results.IsValid)
                    { return true; }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string> ();
                foreach (var error in results.Errors)
                {
                    errors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                }
                _logger.LogError(ex, "Error encountered");
                return false;
            }
            return true;

        }
    }
}
