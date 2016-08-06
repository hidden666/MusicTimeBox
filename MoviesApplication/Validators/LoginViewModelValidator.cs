using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using MoviesApplication.Models;

namespace MoviesApplication.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Invalid Password");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Invalid UserName");
        }
    }
}