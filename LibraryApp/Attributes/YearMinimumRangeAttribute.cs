using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryApp.Attributes
{
    public class YearMinimumRangeAttribute : ValidationAttribute
    {
        private int Minimum { get; set; }
        private int Maximum { get; set; }

        public YearMinimumRangeAttribute(int minimum) 
        {
            this.Minimum = minimum;
            this.Maximum = DateTime.Now.Year;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Data is empty.");
            }

            if (this.Minimum <= ((DateTime)value).Year && this.Maximum >= ((DateTime)value).Year)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date of publication must be newer than 1800 year.");
            }
        }
    }
}