using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataAccessHandlers;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using Models;

namespace ValidationLayer
{
    public class UserLoginValidator : AbstractValidator<UserLoginModel>
    {
        private readonly IDataAccessHandler _dataAccessHandler;
        public UserLoginValidator(IDataAccessHandler dataAccessHandler)
        {
            _dataAccessHandler = dataAccessHandler;

            RuleFor(p => p.Username).NotEmpty().WithMessage("Input a {PropertyName}");
            /*
            RuleFor(p => p.Password)
                .NotEmpty()
                .MustAsync(async (p, _) => )
            */

            RuleFor(p => p.Password)
                .MustAsync(async (context, password, _) =>
                {
                    var username = context.Username;
                    var dataPassword = await MatchPassword(username, password);
                    return dataPassword;
                });
                
            
            /*
            RuleFor(p => p)
               
                 .MustAsync(async (loginModel, _) =>
                 {
                     LoginModel user = await _dataAccessHandler.SearchRepoByName(loginModel.Username);
                     return user.Password == loginModel.Password;
                 })
                
                 .WithMessage("Incorrect Password")
                 .MustAsync(async (loginModel, _) =>
                 {
                     LoginModel user = await _dataAccessHandler.SearchRepoByName(loginModel.Username);
                     return loginModel.Username != null;
                 })
                 .WithMessage("User doesn't exist");   
            */

        }

        private async Task<bool> MatchPassword(string username, string password)
        {
            var user = await _dataAccessHandler.SearchRepoByName(username);
            return password == user.Password;
        }

        private bool VerifyPassword(string password, string storedPassword)
        {
            return password.Equals(storedPassword);
        }
         
    }

}
