using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace _01_BOL.Validation
{
    public class UniqueUserAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("UserId");
            object propertyValue = property.GetValue(instance);
            int.TryParse(propertyValue.ToString(), out int UserId);
            string query = $"SELECT * FROM tasks.users WHERE user_name=value";
            DBaccess.RunScalar(query).ToString();
            string query2 = $"SELECT * FROM tasks.users WHERE (user_id={UserId} AND user_name={value})";
            DBaccess.RunScalar(query2).ToString();


            if (query != null &&query2==null)
                return new ValidationResult("the Name is already exist");
            else return null;
        }

    }
}
