using back_side_Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_side_DataAccess.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int postId);
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(int postId);
    }
}