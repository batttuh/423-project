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

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetUserPosts()
        {
            // fetch the user's email from the token 
            var email = HttpContext.Items["email"];
            if (email == null)
            {
                return Unauthorized();
            }

            // get all posts created by the user's email directly
            var posts = await _postRepository.GetPostsByEmail(email.ToString());

            return Ok(
               posts
            );
        }


        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreate request)
        {
            if(HttpContext.Items["email"]==null){
                return BadRequest();
            }
            string email = HttpContext.Items["email"]!.ToString()!;

            if(await _userRepository.GetUserByEmail(email)==null){
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
            
            User user= await _userRepository.GetUserByEmail(email);
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

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int postId,PostUpdate postUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Post post = await _postRepository.GetPostById(postId);
            post.Title = postUpdate.Title;
            post.PricePerPerson = postUpdate.PricePerPerson;
            post.Description = postUpdate.Description;
            post.Quota= postUpdate.Quota;

            await _postRepository.UpdatePost(post);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postRepository.DeletePost(postId);

            return Ok();
        }
    }
}
