using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using AutoMapper;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using DuckGame.Services;
using DuckGame.Interfaces;

namespace DuckGame.Conrollers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContextEntity _context;
    private readonly IConfiguration _configuration;
    private readonly IUserTokenHandler _userTokenHandler;
     IMapper _mapper;
    public UserController(DataContextEntity context, IConfiguration configuration, IUserTokenHandler userTokenHandler)
    {
        _userTokenHandler = userTokenHandler;
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
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            
            User newUser = new User{
                UserName = user.UserName,
                PasswordHash = passwordHash
            };

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            
            AuthInfo responseObject = new AuthInfo
            {
                Token = _userTokenHandler.CreateToken((User)newUser),
                UserId = newUser.Id,
                UserName = newUser.UserName,
            };

            
            // UserDTO responseUserObject = _mapper.Map<UserDTO>(newUser);
            return Ok(responseObject);
        }
        else 
        {
            return BadRequest("Failed to create user");
        }

    }

}