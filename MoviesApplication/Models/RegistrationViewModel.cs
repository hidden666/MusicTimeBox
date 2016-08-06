using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MoviesApplication.Validators;

namespace MoviesApplication.Models
{
    public class RegistrationViewModel : IValidatableObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new RegistrationValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] {item.PropertyName}));
        }
    }
}