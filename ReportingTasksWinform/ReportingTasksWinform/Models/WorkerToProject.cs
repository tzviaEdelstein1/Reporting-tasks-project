using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
    public class WorkerToProject
    {
      
        public int WorkerToProjectId { get; set; }
   
        public int UserId { get; set; }
    
        public int ProjectId { get; set; }
     
        public int Hours { get; set; }
    }
}
