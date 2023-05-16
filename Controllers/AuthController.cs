using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using DuckGame.Services;

namespace DuckGame.Conrollers;

    
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContextEntity _context;
        private readonly IConfiguration _configuration;
        private readonly UserTokenHandler _userTokenHandler;


        public AuthController(DataContextEntity context, IConfiguration configuration, UserTokenHandler userTokenHandler)
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
                    Token = _userTokenHandler.CreateToken(userDB, _configuration),
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
            var validToken = _userTokenHandler.ValidateToken(token, _configuration);
            User user = _context.Users.FirstOrDefault(u => u.UserName == validToken);
            // if (user == null) return BadRequest("Invalid Token. Please log in again");

            // UserDTO responseObject = new UserDTO
            // {
            //     Id = user.Id,
            //     UserName = user.UserName
            // };
            return Ok(user);

        }




    // private string CreateToken(User user)
    // {
    //     List<Claim> claims = new List<Claim> 
    //     {
    //         // new Claim(ClaimTypes.Name, user.UserName)    
    //         {new Claim("UserName", user.UserName)}
    //     };
        
    //     // key used to create & verify the JWT
    //     //  "SystemSecurityKey" is from: dotnet add package Microsoft.IdentityModel.Tokens
    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
    //         _configuration.GetSection("JwtSettings:Token").Value!));

    //     var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

    //     var token = new JwtSecurityToken(
    //         claims: claims,
    //         expires: DateTime.Now.AddDays(7),
    //         signingCredentials: cred,
    //         issuer: _configuration.GetSection("JwtSettings:Issuer").Value!,
    //         audience: _configuration.GetSection("JwtSettings:Audience").Value!
    //     );

    //     //Create the JWT to be sent back.
    //     var jwt = new JwtSecurityTokenHandler().WriteToken(token);

    //     return jwt;
    // }

    // private string? ValidateToken(string token)
    // {
    //     if (token == null) return null;
    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Token").Value!);

    //     try
    //     {
    //         tokenHandler.ValidateToken(token, new TokenValidationParameters
    //         {
    //             ValidateIssuerSigningKey = true,
    //             IssuerSigningKey = new SymmetricSecurityKey(key),
    //             ValidateIssuer = false,
    //             ValidateAudience = false,
    //             ClockSkew = TimeSpan.Zero
    //         }, out SecurityToken validatedToken);

    //         var jwtToken = (JwtSecurityToken)validatedToken;
    //         var tokenUser = jwtToken.Claims.First(claim => claim.Type == "UserName").Value;

    //         return tokenUser;
    //     }
    //     catch 
    //     {
    //         string expired = "Token expired, please log in again";
    //         return expired;
    //     }
    // }




}