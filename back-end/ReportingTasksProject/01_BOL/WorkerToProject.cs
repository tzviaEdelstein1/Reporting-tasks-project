using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class WorkerToProject
    {
       
        public int WorkerToProjectId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Hours { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }
    }
}
