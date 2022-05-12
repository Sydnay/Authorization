using Authorization.Models;
using Authorization.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApiWithEF.Dtos;

namespace WebApiWithEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly LikedSongsContext repository;
        private readonly IConfiguration configuration;
        public AuthController(IConfiguration configuration, LikedSongsContext repository)
        {
            this.configuration = configuration;
            this.repository = repository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDto request)
        {
            if (repository.GetUser(request.Email) != null)
                return BadRequest("User with this login is already exist");

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                CreatedOn = DateTime.Now,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            var userProfile = new UserProfile
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Gender = request.Gender,
                UserId = user.Id,
                User = user,
                CreatedOn = DateTime.Now
            }


            repository.AddUser(user);
            repository.SaveChanges();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto request)
        {
            var user = repository.GetUser(request.Email);
            if (user == null)
                return NotFound();

            if (!CheckPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("WrongPassword");

            var token = CreateToken(user);
            return Ok(token);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                //new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:TokenKey").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }
        private bool CheckPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }
    }
}
