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
    public class UniqueProjectAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<Project> projects = new List<Project>(); 
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("ProjectId");
            object propertyValue = property.GetValue(instance);
            int.TryParse(propertyValue.ToString(), out int ProjectId);
            projects=ProjectsRequst.GetAllProjects();
                bool isUniqe= projects.Any(project => project.ProjectName.Equals(value.ToString()) && project.ProjectId != ProjectId) == false;
                if (isUniqe==false)
                return new ValidationResult("the ProjectName is already exist");
            else return null;
        }
    }
}
