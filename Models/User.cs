using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [ForeignKey("Post")]
        [Required]
        public int PostID { get; set; }
        [Required]
        public string e_mail { get; set; }
        //public int photo { get; set; }
        [Required]
        public string NameSurname { get; set; }
        public string TiktokAccount { get; set; }
        public string InstagramAccount { get; set; }
        public int TiktokFollowerCount { get; set; }
        public int InstagramFollowerCount { get; set; }

        public Post Post { get; set; }
        public UserType UserType { get; set; }
    }
}
