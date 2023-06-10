using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace back_side_Model.Models
{
    public class User
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserID { get; set; }
        [Required]
        [ForeignKey("UserType")]
        public int UserTypeID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string e_mail { get; set; }
        //public int photo { get; set; }
        [Required]
        public string? NameSurname { get; set; }
        public string? TiktokAccount { get; set; }
        public string? InstagramAccount { get; set; }
        public int TiktokFollowerCount { get; set; }
        public int InstagramFollowerCount { get; set; }
        public UserType UserType { get; set; }
    }
    public class UserLogin{
            
            public string e_mail { get; set; }
    
            public string Password { get; set; }
    }
    public class UserRegister{

        public string Name { get; set; }
 
        public string Password { get; set; }
        public int UserTypeID { get; set; }

        public int PostID { get; set; }

        public string e_mail { get; set; }
        //public int photo { get; set; }
        public string? NameSurname { get; set; }
        public string? TiktokAccount { get; set; }
        public string? InstagramAccount { get; set; }
        public int TiktokFollowerCount { get; set; }
        public int InstagramFollowerCount { get; set; }
        
    }
}
