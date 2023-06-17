using Microsoft.AspNetCore.Mvc;
using back_side_Model.Models;
using back_side_DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;        
        private readonly IUserRepository _userRepository;



        public CommentController(ICommentRepository commentRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;            
            _postRepository = postRepository;
            _userRepository = userRepository;


        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepository.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await _postRepository.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        


        [HttpPost]
        public async Task<IActionResult> CreateComment(SaveComment request)
        {
            if (HttpContext.Items["email"] == null)
            {
                return BadRequest();
            }
            string email = HttpContext.Items["email"]!.ToString()!;

            if (_userRepository.GetUserByEmail(email) == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           

            User user = _userRepository.GetUserByEmail(email);
            Post post = await _postRepository.GetPostById(request.PostID); 
            var comment = new Comment
            {
                
                Description = request.Description,
                UserID = user.UserID,                
                User = user,
                PostID = request.PostID,
                Post = post
                
            };
            await _commentRepository.CreateComment(comment);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(int commentId, SaveComment commentUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepository.GetCommentByCommentID(commentId);

            if (comment == null)
            {
                return NotFound("Comment not found.");
            }


            comment.Description = commentUpdate.Description;
            

            await _commentRepository.UpdateComment(comment);

            return Ok();
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await _commentRepository.DeleteComment(commentId);
            return Ok();
        }

    }
}
