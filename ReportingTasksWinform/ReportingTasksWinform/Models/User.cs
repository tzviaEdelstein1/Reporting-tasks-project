using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Models
{
   public class User
    {
        public int UserId { get; set; }  
        public string UserName { get; set; }
        public string UserEmail { get; set; } 
        public string Password { get; set; }
        public int TeamLeaderId { get; set; }   
        public int UserKindId { get; set; }
    }
}
