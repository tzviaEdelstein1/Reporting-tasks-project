using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class UserKindToAccess
    {
        [Required]
        public int UserKindToAccessId { get; set; }
        [Required]
        public int userKindId { get; set; }
        [Required]
        public int AccessId { get; set; }

    }
}
