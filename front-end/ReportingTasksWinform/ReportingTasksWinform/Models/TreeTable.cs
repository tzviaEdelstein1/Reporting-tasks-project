using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
  public  class TreeTable
    {
        public Project Project { get; set; }
        public List<DetailsWorkerInProjects> DetailsWorkerInProjects { get; set; }
    }
}
