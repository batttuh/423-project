using back_side_Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_side_DataAccess.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentByPostID(int postId);
        
        Task CreateComment(Comment comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int commentId);
        Task<Comment> GetCommentByCommentID(int commentId);
    }
}