using _01_BOL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class Project
    {
        public int ProjectId { get; set; }
        [Required]
       [UniqueProjectAttribute]
        public string ProjectName { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public int TeamLeaderId { get; set; }
        [Required]
        public int DevelopersHours { get; set; }
        [Required]      
        public int QaHours { get; set; }
        [Required]
      
        public int UiUxHours { get; set; }
        [ValidateStartDate]
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
    



    }
}
