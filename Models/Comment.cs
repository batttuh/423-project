using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_side_Model.Models
{
	public class Comment
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int CommentID { get; set; }
		
		[Required]
		public string Description { get; set; }
		
		[Required]
		[ForeignKey("User")]
		public int UserID { get; set; }

		[Required]
		[ForeignKey("Post")]
		public int PostID { get; set; }

		public User User { get; set; }
		public Post Post { get; set; }
	}
	public class SaveComment
	{		
		public int PostID { get; set; }
		public string Description { get; set; }
		
	}

	
}

