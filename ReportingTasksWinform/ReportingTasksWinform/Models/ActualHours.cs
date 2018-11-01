using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
   public class ActualHours
    {
        [Required]
        public int ActualHoursId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public double CountHours { get; set; }
        [Required]
        public DateTime date { get; set; }



    }
}
