using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataAccessHandlers;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
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
            RuleFor(p => p.Password).NotEmpty();
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
        }
         
    }

}
