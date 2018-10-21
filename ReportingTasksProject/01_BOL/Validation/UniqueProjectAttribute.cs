using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validation
{
   public class UniqueProjectAttribute:ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string query = $"SELECT * FROM tasks.projects WHERE project_name=value";
            DBaccess.RunScalar(query).ToString();
            if (query != null)
                return new ValidationResult("the ProjectName is already exist");
            else return null;
        }
    }
}
