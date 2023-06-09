using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using back_side_Model.Models;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
         private readonly IConfiguration _configuration;

        public AuthController(IUserRepository userRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User request)
        {
            Console.WriteLine("Registering user");
            
              if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if the username is already taken
        if (_userRepository.GetUserByEmail(request.e_mail) != null)
        {
            ModelState.AddModelError("Username", "Username is already taken.");
            return BadRequest(ModelState);
        }

      

        // Save the user to the database
        _userRepository.CreateUser(request);

        return Ok();
           
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User request)
        {
            
            if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if the user exists
        var user = _userRepository.GetUserByEmail(request.e_mail);
        if (user == null)
        {
            ModelState.AddModelError("Username", "Invalid username or password.");
            return BadRequest(ModelState);
        }

        // Validate the password
        if (!_userRepository.VerifyPassword(request.Password,user.Password))
        {
            ModelState.AddModelError("Username", "Invalid username or password.");
            return BadRequest(ModelState);
        }

        // TODO: Generate and return an authentication token (e.g., JWT) for the logged-in 
        GenerateJwtToken(user);

        return Ok();
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