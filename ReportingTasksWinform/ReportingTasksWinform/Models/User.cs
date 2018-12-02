using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ReportingTasksWinform.Models
{
   public class User
    {
        public int UserId { get; set; }
        [Required]
        [MinLength(2), MaxLength(10)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
     
        [MinLength(5)]
        public string Password { get; set; }
        public int TeamLeaderId { get; set; }
        [Required]
        public int UserKindId { get; set; }

        public string UserIP { get; set; }
    }
}
