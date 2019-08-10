using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Attributes
{
    public class NameisValidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((List<AuthorModel>)value).Any(x=>string.IsNullOrWhiteSpace(x.FirstName) && string.IsNullOrWhiteSpace(x.LastName) == false))
            {
                return new ValidationResult("Please add First name. It must not be empty.");
            }

            if (((List<AuthorModel>)value).Any(x => string.IsNullOrWhiteSpace(x.LastName) && string.IsNullOrWhiteSpace(x.FirstName) == false))
            {
                return new ValidationResult("Please add Last name. It must not be empty.");
            }

            return ValidationResult.Success;
        }
    }
}