using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class StockBetween1And20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var stock = ((Movie)validationContext.ObjectInstance).Stock;

            if (stock == 0)
                return new ValidationResult("The Stock field is required");

            if (stock >= 1 && stock <= 20)
                return ValidationResult.Success;
            else
                return new ValidationResult("The stock must be between 1 and 20");
        }
    }
}