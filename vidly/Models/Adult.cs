using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Adult : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Vip || customer.MembershipTypeId == MembershipType.unknown)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Now.Year - customer.Birthday.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Member should be as minimum 18 years old");
        }
    }
}