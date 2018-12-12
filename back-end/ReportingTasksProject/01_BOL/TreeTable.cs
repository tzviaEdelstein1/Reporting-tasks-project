using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL
{
    public class TreeTable
    {
        public Project Project { get; set; }
        public List<DetailsWorkerInProjects> DetailsWorkerInProjects { get; set; }
    }
}
