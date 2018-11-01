using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validation
{
   public class ValidateStartDate: ValidationAttribute
    {

        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.Parse(value.ToString()) >= DateTime.Now)
            {
                return null;

            }
                return new ValidationResult("Date start has to be bigger than today");      
        }
    }
}
