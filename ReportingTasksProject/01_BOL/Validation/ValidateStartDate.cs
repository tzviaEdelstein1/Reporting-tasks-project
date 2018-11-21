using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validation
{
   public class ValidateStartDate: ValidationAttribute
    {

        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("ProjectId");
            object propertyValue = property.GetValue(instance);
            int.TryParse(propertyValue.ToString(), out int ProjectId);
            string query = $"SELECT project_id FROM tasks.projects WHERE project_id={ProjectId}";
            var q1 = DBaccess.RunScalar(query);

            if (DateTime.Parse(value.ToString()) >= DateTime.Now.AddDays(-1)|| query!=null)
            {
                return null;

            }
                return new ValidationResult("Date start has to be bigger than today");      
        }
    }
}
