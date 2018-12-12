using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Validation
{
    public class UniqueUserAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<User> users = UserRequsts.GetAllUsers();
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("UserId");
            object propertyValue = property.GetValue(instance);
            int.TryParse(propertyValue.ToString(), out int UserId);
            bool isUniqe = users.Any(user => user.UserName.Equals(value.ToString()) && user.UserId != UserId) == false;
            if (isUniqe == false)
                return new ValidationResult("the Name is already exist");
            else return null;
        }

    }
}
