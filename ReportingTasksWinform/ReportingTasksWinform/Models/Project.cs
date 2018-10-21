using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
   public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
     
        public string ClientName { get; set; }
     
        public int TeamLeaderId { get; set; }
    
        public int DevelopersHours { get; set; }
    
        public int QaHours { get; set; }
       
        public int UiUxHours { get; set; }

  
        public DateTime StartDate { get; set; }
       
        public DateTime FinishDate { get; set; }


    }
}
