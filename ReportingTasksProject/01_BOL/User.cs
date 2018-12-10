using _01_BOL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class User
    { 
        public int UserId { get; set; }
        [Required]
        [UniqueUserAttribute]
        [MinLength(2),MaxLength(10)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

       
        public string Password { get; set; }
        public int TeamLeaderId { get; set; }
        [Required]
        public int UserKindId { get; set; }
        public string UserIP { get; set; }
        public string VerifyPassword { get; set; }
    }
}
