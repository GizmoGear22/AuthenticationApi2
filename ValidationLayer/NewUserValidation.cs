using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Models;

namespace ValidationLayer
{
    public class NewUserValidation : AbstractValidator<NewUserModel>
    {
        public NewUserValidation() 
        {
            RuleFor(p => p.Name).NotEmpty().Length(2, 50);
            RuleFor(p => p.Password).NotEmpty().Length(7, 50).Equal(p => p.CheckPassword);
        }
    }
}
