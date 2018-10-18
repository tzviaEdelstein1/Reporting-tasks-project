using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
  public  class UserKind
    {
        [Required]
        public int KindUserId { get; set; }
        [Required]
        public string KindUserName { get; set; }
    }
}
