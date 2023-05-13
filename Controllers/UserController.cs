using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using AutoMapper;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace DuckGame.Conrollers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContextEntity _context;
    private readonly IConfiguration _configuration;

    IMapper _mapper;
    public UserController(DataContextEntity context, IConfiguration configuration)
    {
        _configuration = configuration;
        _context = context;
        _mapper = new Mapper(new MapperConfiguration(config => {
            config.CreateMap<UserDTO, User>();
        }));
    }

    [HttpGet("{userId}/heroes")]
    public IEnumerable<Hero> UserHeroes(int userId)
    {
        var heroes = _context.Heroes.Where(c => c.UserId == userId);
        return heroes;
    }

    [HttpPost("createuser")]
    public async Task<ActionResult<User>> CreateNewUser(UserDTO user)
    {



        var doesExist = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
        if (doesExist != null) return BadRequest("Username already exists");
        if (user.UserName == "") return BadRequest("Username cannot be blank");
        

        if (user.UserName != "" && doesExist == null) 
        {
            User newUser = new User();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            newUser.UserName = user.UserName;
            newUser.PasswordHash = passwordHash;

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            // string token = CreateToken(newUser);
            return Ok("Account created successfully");
        }
        else 
        {
            return BadRequest("Failed to create user");
        }

    }

    //Create the JWT to be sent back.
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
    //         expires: DateTime.Now.AddSeconds(20),
    //         signingCredentials: cred,
    //         issuer: _configuration.GetSection("JwtSettings:Issuer").Value!,
    //         audience: _configuration.GetSection("JwtSettings:Audience").Value!
    //     );

    //     //Create the JWT to be sent back.
    //     var jwt = new JwtSecurityTokenHandler().WriteToken(token);

    //     return jwt;
    // }




}