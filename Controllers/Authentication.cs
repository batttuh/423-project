using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using back_side_Model.Models;
using back_side_DataAccess.Repositories;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
         private readonly IConfiguration _configuration;
         private readonly IUserTypeRepository _userTypeRepository;

        public AuthController(IUserRepository userRepository,IConfiguration configuration,IUserTypeRepository userTypeRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userTypeRepository = userTypeRepository;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister request)
        {
            
              if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if the username is already taken
        if (await _userRepository.GetUserByEmail(request.e_mail) != null)
        {
            ModelState.AddModelError("Username", "Username is already taken.");
            return BadRequest(ModelState);
        }
        UserType userType=await _userTypeRepository.GetUserTypeById(request.UserTypeID);
        var user = new User
                {
                    UserTypeID = request.UserTypeID,
                    Name = request.Name,
                    Password = request.Password,
                    e_mail = request.e_mail,
                    NameSurname = request.NameSurname,
                    TiktokAccount = request.TiktokAccount,
                    InstagramAccount = request.InstagramAccount,
                    TiktokFollowerCount = request.TiktokFollowerCount,
                    InstagramFollowerCount = request.InstagramFollowerCount,
                    UserType = userType
                };
        
        // Save the user to the database
        _userRepository.CreateUser(user);

        return Ok();
           
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin request)
        {

            if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if the user exists
        var user = await _userRepository.GetUserByEmail(request.e_mail);
        if (user == null)
        {
            ModelState.AddModelError("Username", "Invalid username or password.");
            return BadRequest(ModelState);
        }

        // Validate the password
        if (!_userRepository.VerifyPassword(user,request.Password,user.Password))
        {
            ModelState.AddModelError("Username", "Invalid username or password.");
            return BadRequest(ModelState);
        }

        // TODO: Generate and return an authentication token (e.g., JWT) for the logged-in 
        var token = GenerateJwtToken(user);

         return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
             var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.e_mail)
                }),
                Expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:ExpirationDays"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}