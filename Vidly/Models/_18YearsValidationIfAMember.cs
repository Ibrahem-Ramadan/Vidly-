using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Models
{
   
    public class _18YearsValidationIfAMember : ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.UnKnown ||
               customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success ;
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is Required.");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer Should be at Least 18 Years Old to Member");
        }
    }
}