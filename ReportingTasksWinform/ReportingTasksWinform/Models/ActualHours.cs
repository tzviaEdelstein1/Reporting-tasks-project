using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
   public class ActualHours
    {
        public int ActualHoursId { get; set; }
     
        public int UserId { get; set; }
      
        public int ProjectId { get; set; }
      
        public double CountHours { get; set; }
    
        public DateTime date { get; set; }

    }
}
