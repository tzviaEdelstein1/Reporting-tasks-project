using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace _01_BOL.Validation
{
   public class UniqueUserAttribute: ValidationAttribute
    {        
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        { 
            string query = $"SELECT * FROM tasks.users WHERE user_name=value";
            DBaccess.RunScalar(query).ToString();
            if (query != null)
                return new ValidationResult("the Name is already exist");
            else return null;
        }

    }
}
