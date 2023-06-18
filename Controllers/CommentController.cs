using Microsoft.AspNetCore.Mvc;
using back_side_Model.Models;
using back_side_DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using back_side_Model.DTO;

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

            if (await _userRepository.GetUserByEmail(email) == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           

            User user = await _userRepository.GetUserByEmail(email);
        
                var post = await _postRepository.GetPostById(request.PostID);
        
            if (post == null)         
            {
                return NotFound("Post not found.");
            }
            var comment = new Comment
            {
                ShareURL = request.ShareURL,
                UserID = user.UserID,                
                PostID = request.PostID,                
            };
            await _commentRepository.CreateComment(comment);

            return Ok();
        }


        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateComment(int commentId, SaveComment commentUpdate)
        {
              if (HttpContext.Items["email"] == null)
            {
                return BadRequest();
            }
            string email = HttpContext.Items["email"]!.ToString()!;

            if (await _userRepository.GetUserByEmail(email) == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepository.GetCommentByCommentID(commentId);

            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            if(!comment.User.e_mail.Equals(email))
            {
                return BadRequest("You are not authorized to update this comment.");
            }
            comment.ShareURL = commentUpdate.ShareURL;
            

            await _commentRepository.UpdateComment(comment);

            return Ok();
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
              if (HttpContext.Items["email"] == null)
            {
                return BadRequest();
            }
            string email = HttpContext.Items["email"]!.ToString()!;

            if (await _userRepository.GetUserByEmail(email) == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepository.GetCommentByCommentID(commentId);
              if (comment == null)
            {
                return NotFound("Comment not found.");
            }
     
            if(!comment.User.e_mail.Equals(email))
            {
                return BadRequest("You are not authorized to delete this comment.");
            }
            await _commentRepository.DeleteComment(commentId);
            return Ok();
        }
        
          [HttpGet("getAllComment/{postID}")]
        public async Task<IActionResult> GetCommentByPostID(int postId)
        {
              if (HttpContext.Items["email"] == null)
            {
                return BadRequest();
            }
            string email = HttpContext.Items["email"]!.ToString()!;

            if (await _userRepository.GetUserByEmail(email) == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var allComments = await _commentRepository.GetAllCommentByPostID(postId);
            var mappedComments = allComments.Select(c => new CommentDTO
            {
                CommentID = c.CommentID,
                ShareURL = c.ShareURL,
                User = new UserDTO(
                      c.User.UserID,
                     c.User.Name,
                     c.User.e_mail,
                     c.User.NameSurname,
                     c.User.TiktokAccount,
                     c.User.InstagramAccount,
                      c.User.TiktokFollowerCount,
                     c.User.InstagramFollowerCount
                )
            }).ToList();
            if (allComments == null)
            {
                return NotFound();
            }
            return Ok(mappedComments);
        }

        

    }
}
