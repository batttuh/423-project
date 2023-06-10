using Microsoft.AspNetCore.Mvc;
using back_side_Model.Models;
using back_side_DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IUserRepository _userRepository;

        public PostController(IPostRepository postRepository,IAdvertisementRepository advertisementRepository,IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _advertisementRepository = advertisementRepository;
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
        public async Task<IActionResult> CreatePost(PostCreate request)
        {
            if(HttpContext.Items["email"]==null){
                return BadRequest();
            }
            string email = HttpContext.Items["email"]!.ToString()!;

            if(_userRepository.GetUserByEmail(email)==null){
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Advertisement advertisement=new Advertisement{
                FollowerBottomLimit=request.AdvertisementCreate.FollowerBottomLimit,
                FollowerUpperLimit=request.AdvertisementCreate.FollowerUpperLimit,
                ViewsBottomLimit=request.AdvertisementCreate.ViewsBottomLimit
            };
            await _advertisementRepository.CreateAdvertisement(advertisement);
            
            User user= _userRepository.GetUserByEmail(email);
            var post=new Post{
                Title=request.Title,
                Description=request.Description,
                UserID=user.UserID,
                AdvertisementID=advertisement.AdvertisementID,
                User=user,
                Quota=request.Quota,
                PricePerPerson=request.PricePerPerson,
                Advertisement=advertisement
            };
            await _postRepository.CreatePost(post);

            return Ok();
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (postId != post.PostID)
            {
                return BadRequest();
            }

            await _postRepository.UpdatePost(post);

            return Ok();
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postRepository.DeletePost(postId);

            return Ok();
        }
    }
}
