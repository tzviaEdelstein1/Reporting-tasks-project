using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validation
{
   public class ValidateEndDate: ValidationAttribute
    {

        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("StartDate");
            object propertyValue = property.GetValue(instance);
            DateTime.TryParse(propertyValue.ToString(), out DateTime StartDate);

            if ((DateTime)value<(DateTime)StartDate)
            {
                return null;

            }
            return new ValidationResult("Date end has to be bigger than start date");
        }
    }
}
