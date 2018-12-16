using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
  public  class ActualHours
    {
    
        public int ActualHoursId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid double Number")]
        public double CountHours { get; set; }
        [Required]
        public DateTime date { get; set; }


    }
}
