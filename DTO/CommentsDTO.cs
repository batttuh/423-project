

using back_side_Model.Models;

namespace back_side_Model.DTO
{
	public class CommentDTO
	{
		public int CommentID { get; set; }

		public string ShareURL { get; set; }

		public UserDTO User { get; set; }
	}
}