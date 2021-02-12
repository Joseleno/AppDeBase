using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace AppDeBase.Extensions
{
    public class DeviseAtribut : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var Devise = Convert.ToDecimal(value, new CultureInfo("fr-CA"));
            }
            catch (Exception)
            {
                return new ValidationResult("Le prix au format non valide");
            }

            return ValidationResult.Success;
        }
    }
}