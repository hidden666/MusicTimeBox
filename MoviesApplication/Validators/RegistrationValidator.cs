using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using MoviesApplication.Models;

namespace MoviesApplication.Validators
{
    public class RegistrationValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Invalid Password");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Invalid UserName");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email");
        }
    }
}