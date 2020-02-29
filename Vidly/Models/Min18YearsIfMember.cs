using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var customer= (Customer)validationContext.ObjectInstance;
           if(customer.MembershipTypeId==MembershipType.Unknown
              || customer.MembershipTypeId ==MembershipType.PayAsYouGo)
           {
               return ValidationResult.Success;
           }

           if (customer.BirthDate == null)
           {
               return new ValidationResult("Birth Date is Required");
           }

            return((DateTime.Today.Year - customer.BirthDate.Value.Year >= 18)?
                ValidationResult.Success:
                new ValidationResult("Must be older then 18 years old to hold a membership"));


        }
    }
}