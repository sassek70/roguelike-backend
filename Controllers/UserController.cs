using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using AutoMapper;

namespace DuckGame.Conrollers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContextEntity _context;
    IMapper _mapper;
    public UserController(DataContextEntity context)
    {
        _context = context;
        _mapper = new Mapper(new MapperConfiguration(config => {
            config.CreateMap<UserDTO, User>();
        }));
    }

    [HttpGet("user/{userId}/heroes")]
    public IEnumerable<Hero> UserHeroes(int userId)
    {
        var heroes = _context.Heroes.Where(c => c.UserId == userId);
        return heroes;
    }

    [HttpPost("user/createuser")]
    public async Task<ActionResult<User>> CreateNewUser(User user)
    {
        // User userDb = new User();
        // User userDb = _mapper.Map<User>(user);

        // userDb.UserName = user.UserName;

        if (user.UserName != "") 
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        else 
        {
            throw new Exception("Failed to create user");
        }

    // [HttpPost("user/{userId}/createhero")]
    // public IActionResult CreateNewHero(int userId, HeroDTO heroDTO)
    // {
    //     Hero heroDB = _mapper.Map<Hero>(heroDTO);
    //     heroDB.UserId = userId;

    //     _context.Add(heroDB);
    //     if (_context.SaveChanges() > 0)
    //     {
    //         return Ok();
    //     }

    //     throw new Exception("Failed to create hero");
    }
}