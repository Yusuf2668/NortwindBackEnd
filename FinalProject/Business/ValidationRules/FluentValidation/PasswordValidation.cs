using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PasswordValidation : AbstractValidator<UserForRegisterDto>
    {
        public PasswordValidation()
        {
            RuleFor(U => U.Password).MinimumLength(5);
            RuleFor(U => U.Password).NotEmpty();
            RuleFor(U => U.Email).NotEmpty();
            RuleFor(U => U.FirstName).NotEmpty();
            RuleFor(U => U.LastName).NotEmpty();
        }
    }
}
