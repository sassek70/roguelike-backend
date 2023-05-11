using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace DuckGame.Conrollers;

    
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContextEntity _context;
        private readonly IConfiguration _configuration;


        public AuthController(DataContextEntity context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        
        [HttpPost("login")]
        public ActionResult<User> Register(UserDTO user)
        {
            var userDB = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();

            if (userDB != null && !BCrypt.Net.BCrypt.Verify(user.Password, userDB.PasswordHash))
            {
                return BadRequest("Invalid Username or Password");
            }

            return user;
        }
    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim> 
        {
            new Claim(ClaimTypes.Name, user.UserName)    
        };

        // key used to create & verify the JWT
        //  "SystemSecurityKey" is from: dotnet add package Microsoft.IdentityModel.Tokens
        // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        //     _config.GetSection("JwtSettings:Token").Value!));

        // var key1 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        //     _configuration.GetSection("JwtSettings:Token").Value!));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("JwtSettings:Token").Value!));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }



        //Create the JWT to be sent back.

}