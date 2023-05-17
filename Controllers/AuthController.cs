using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using DuckGame.Services;
using DuckGame.Interfaces;

namespace DuckGame.Conrollers;

    
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContextEntity _context;
        private readonly IConfiguration _configuration;
        private readonly IUserTokenHandler _userTokenHandler;


        public AuthController(DataContextEntity context, IConfiguration configuration, IUserTokenHandler userTokenHandler)
        {
            _userTokenHandler = userTokenHandler;
            _configuration = configuration;
            _context = context;
        }
        
        [HttpPost("login")]
        public ActionResult<User> LoginCreateToken([FromBody] UserDTO user)
        {
            var userDB =  _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            if (userDB == null) return NotFound("Username does not exist");
            if (userDB != null && BCrypt.Net.BCrypt.Verify(user.Password, userDB.PasswordHash))
            {
                AuthInfo responseObject = new AuthInfo
                {
                    Token = _userTokenHandler.CreateToken(userDB),
                    UserId = userDB.Id,
                    UserName = userDB.UserName,
                };
                
                return Ok(responseObject);
            }
            return BadRequest("Invalid Username or Password");
        }

        [HttpPost("existingtoken")]
        public ActionResult<User> ExistingToken([FromBody] string token)
        {
            var validToken = _userTokenHandler.ValidateToken(token);
            User user = _context.Users.FirstOrDefault(u => u.UserName == validToken);
            // if (user == null) return BadRequest("Invalid Token. Please log in again");

            AuthInfo responseObject = new AuthInfo
            {
                Token = _userTokenHandler.CreateToken(user),
                UserId = user.Id,
                UserName = user.UserName,
            };
            
            return Ok(responseObject);

        }
}