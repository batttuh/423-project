using back_side_DataAccess.Data;
using back_side_Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_side_DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }        

        public async Task CreateComment(Comment comment)
        {
            try
            {
                _context.Comment.Add(comment);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
          }

        public async Task UpdateComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _context.Comment.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comment.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Comment>> GetAllCommentByPostID(int postId)
        {
            var post = await _context.Posts.Where(u => u.PostID == postId).Select(
                u => new Post
                {
                    PostID = u.PostID,
                    UserID = u.UserID,
                    AdvertisementID = u.AdvertisementID,
                    Title = u.Title,
                    Description = u.Description,
                    User = u.User,
                    Advertisement = u.Advertisement
                    
                }).FirstOrDefaultAsync();
            if (post == null)
            {
                throw new Exception("No such post.");
            }

        var comments = await _context.Comment.Where(p => p.PostID == post.PostID).Select(p => new Comment
            {
                CommentID = p.CommentID,
                ShareURL = p.ShareURL,
                UserID = p.UserID,
                PostID = p.PostID,
                User = p.User,
                Post = post                
            }).ToListAsync();
            return comments;
        }

        public async Task<Comment> GetCommentByCommentID(int commentId)
        {


            var comments = await _context.Comment.Where(p => p.CommentID == commentId).Select(p => new Comment
            {
                CommentID = p.CommentID,
                ShareURL = p.ShareURL,
                UserID = p.UserID,
                PostID = p.PostID,
                User = p.User,
                Post = p.Post
            }).FirstOrDefaultAsync();
            
            return comments;
        }


    }
}