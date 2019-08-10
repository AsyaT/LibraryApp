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
            if (((List<AuthorModel>)value) != null && ((List<AuthorModel>)value).Count > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Collection is empty");
        }
    }
}