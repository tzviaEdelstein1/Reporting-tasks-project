﻿using System;
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
      
        public int Hours { get; set; }
    }
}
