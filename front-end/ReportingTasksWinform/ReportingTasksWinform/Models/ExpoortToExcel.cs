using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
   public class ExportToExcel
    {
        public string Name { get; set; }
        public string TeamLeaderName { get; set; }    
        public string Kind { get; set; }
        public int? Hours { get; set; }
        public string Customer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? Date { get; set; }
        public double? CountHours { get; set; }

    }
}
