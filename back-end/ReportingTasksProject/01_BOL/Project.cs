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
        [RegularExpression("[a-zA-Z]", ErrorMessage = "only alphabet")]
        public string ProjectName { get; set; }
        [RegularExpression("[a-zA-Z]", ErrorMessage = "only alphabet")]
        [Required]
        public string ClientName { get; set; }
        [Required]
        public int TeamLeaderId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        [Required]
        public int DevelopersHours { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required]      
        public int QaHours { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        public int UiUxHours { get; set; }
        [ValidateStartDate]
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
        public User User { get; set; }

        public bool IsActive { get; set; }


    }
}
