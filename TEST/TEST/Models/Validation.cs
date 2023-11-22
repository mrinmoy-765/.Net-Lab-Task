using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TEST.Models
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string password)
            {
                             if (password.Length < 8)
                {
                    return false;
                }
                           if (password.Count(char.IsLetter) < 2)
                {
                    return false;
                }
                            if (!password.Any(char.IsDigit))
                {
                    return false;
                }
                            if (password.Count(char.IsPunctuation) < 2)
                {
                    return false;
                }
                           if (password.Contains(' '))
                {
                    return false;
                }
                return true;
            }

                 return false;
        }


    }

    public class AgeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateOfBirth)
            {
                int age = DateTime.Today.Year - dateOfBirth.Year;

                if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                return age > 18;
            }

            return false;
        }
    }




    //checking


    public class IdEmailMatchAttribute : ValidationAttribute
    {
        private readonly string idPropertyName;

        public IdEmailMatchAttribute(string idPropertyName)
        {
            this.idPropertyName = idPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var emailValue = value as string;
            if (emailValue == null)
            {
                return ValidationResult.Success;
            }

            // Get the value of the StudentId property using reflection
            var idPropertyInfo = validationContext.ObjectType.GetProperty(idPropertyName);
            if (idPropertyInfo == null)
            {
                throw new ArgumentException("Property with the given name not found");
            }

            var idValue = idPropertyInfo.GetValue(validationContext.ObjectInstance) as string;
            if (idValue == null)
            {
                return ValidationResult.Success;
            }

            // Check if both values have the same pattern
            if (IsValidPattern(idValue) && IsValidPattern(emailValue))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The {validationContext.DisplayName} and {idPropertyName} values do not match.");
            }
        }

        private bool IsValidPattern(string value)
        {
            // Use Regex.IsMatch to validate the pattern
            return Regex.IsMatch(value, @"^\d{2}-\d{5}-\d{1}$");
        }
    }







}