using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL
{
  public  class DetailsWorkerInProjects
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public int Hours { get; set; }
        public List<ActualHours> ActualHours { get; set; }
      
    }
}
