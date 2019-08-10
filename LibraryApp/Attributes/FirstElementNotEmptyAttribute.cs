using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Attributes
{
    public class FirstElementNotEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // TODO : refactoring
            if (((List<AuthorModel>)value) != null && ((List<AuthorModel>)value).Count > 0 )
            {
                AuthorModel firstElemnt = ((List<AuthorModel>)value).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(firstElemnt.FirstName) == false && string.IsNullOrWhiteSpace(firstElemnt.LastName) == false && firstElemnt.FirstName.Length<=20 && firstElemnt.LastName.Length <= 20)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(firstElemnt.FirstName))
                    {
                        return new ValidationResult("First name can't be empty.");
                    }

                    if (string.IsNullOrWhiteSpace(firstElemnt.LastName))
                    {
                        return new ValidationResult("Last name can't be empty.");
                    }
                }
            }
            return new ValidationResult("Invalid collection");
        }
    }
}