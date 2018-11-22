using ReportingTasksWinform.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
   public class Project
    {
        public static  readonly string[] FieldNames = { "ProjectName", "ClientName", "TeamLeaderName", "DevelopersHours", "QaHours", "UiUxHours" };
        public int ProjectId { get; set; }
        [Required]
        [UniqueProjectAttribute]
        public string ProjectName { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public int TeamLeaderId { get; set; }
        [Required]
        public int DevelopersHours { get; set; }
        [Required]
        public int QaHours { get; set; }
        [Required]
        public int UiUxHours { get; set; }
        [ValidateStartDate]
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [ValidateEndDate]
        public DateTime FinishDate { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
    }
}
