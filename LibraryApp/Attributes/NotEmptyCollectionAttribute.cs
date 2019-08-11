using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Attributes
{
    public class NotEmptyCollectionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((List<AuthorModel>)value) == null)
            {
                return new ValidationResult("Collection is not initialized.");
            }

            if( ((List<AuthorModel>)value).Count == 0)
            {
                return new ValidationResult("Collection is empty. Please add at least one author.");
            }

            if (((List<AuthorModel>)value).Any(x => string.IsNullOrWhiteSpace(x.FirstName) == false && string.IsNullOrWhiteSpace(x.LastName) == false))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Please add at least one valid author name.");
            }
        }
    }
}