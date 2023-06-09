using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
    public class Application
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ApplicationID { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        [ForeignKey("Post")]
        public int PostID { get; set; }
        [Required]
        public string ShareURL { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}
