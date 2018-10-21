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
   public class UniqueProjectAttribute:ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("ProjectId");
            object propertyValue = property.GetValue(instance);
            int.TryParse(propertyValue.ToString(), out int ProjectId);
            string query = $"SELECT * FROM tasks.projects WHERE project_name={value}";
            DBaccess.RunScalar(query).ToString();
            string query2 = $"SELECT * FROM tasks.projects WHERE (project_id={ProjectId} AND project_name={value})";
            DBaccess.RunScalar(query2).ToString();

            if (query != null&&query2==null)
                return new ValidationResult("the ProjectName is already exist");
            else return null;
        }
    }
}
