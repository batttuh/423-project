using back_side_DataAccess.Data;
using back_side_Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_side_DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts= await _context.Posts.ToListAsync<Post>();
             foreach (var post in posts)
            {
                post.Advertisement = await _context.Advertisements.FirstOrDefaultAsync(a => a.AdvertisementID == post.AdvertisementID);
                post.User = await _context.Users.Where(a => a.UserID == post.UserID).FirstOrDefaultAsync();
                post.User.UserType = await _context.UserTypes.Where(a => a.UserTypeID == post.User.UserTypeID).FirstOrDefaultAsync();
            }
            return posts;
        }

        public async Task<Post> GetPostById(int postId)
        {
            Post? post=await _context.Posts.Where(x=>x.PostID==postId).Select(
                x=>new Post{
                    PostID=x.PostID,
                    UserID=x.UserID,
                    AdvertisementID=x.AdvertisementID,
                    Title=x.Title,
                    Description=x.Description,
                    Quota=x.Quota,
                    PricePerPerson=x.PricePerPerson,
                    User=x.User,
                    Advertisement=x.Advertisement
                }
            ).FirstOrDefaultAsync();
            return post;
        }

        public async Task CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetPostsByEmail(string email)
        {
           var user = await _context.Users.FirstOrDefaultAsync(u => u.e_mail == email);
            if (user == null)
            {
                throw new Exception("No such user.");
            }

            var posts = await _context.Posts.Where(p => p.UserID == user.UserID).ToListAsync();
            
            foreach (var post in posts)
            {
                post.Advertisement = await _context.Advertisements.FirstOrDefaultAsync(a => a.AdvertisementID == post.AdvertisementID);
            }
            
            return posts;
        }


    }
}