using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UsersValidator : AbstractValidator<User>
    {
        public UsersValidator()
        {
            RuleFor(p => p.firstName).MinimumLength(2).NotEmpty();
            RuleFor(p => p.lastName).NotEmpty();
            RuleFor(p => p.email).EmailAddress().NotEmpty();
            RuleFor(p => p.phone).NotEmpty();



        }
    }
}
