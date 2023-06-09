using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
    public class UserType
    {
        [Required]
        public int UserTypeID { get; set; }
        [Required]
        public string UserTypeName { get; set; }
    }
}
