using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
  public  class DetailsWorkerInProjects
    {
        public static readonly string[] FieldNames = { "TeamLeaderName", "Name",  "Hours", "ActualHours","Precent"};
        public int UserId { get; set; }
        public string TeamLeaderName { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public int Hours { get; set; }
        public List<ActualHours> ActualHours { get; set; }
    }
}
