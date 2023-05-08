using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using AutoMapper;

namespace DuckGame.Conrollers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    private readonly DataContextEntity _context;
    IMapper _mapper;
    public HeroController(DataContextEntity context)
    {
        _context = context;
        _mapper = new Mapper(new MapperConfiguration(config => {
            config.CreateMap<HeroDTO, Hero>();
        }));
    }

    [HttpPost("user/{userId}/createhero")]
    public IActionResult CreateNewHero(int userId, HeroDTO heroDTO)
    {
        Hero heroDB = _mapper.Map<Hero>(heroDTO);
        heroDB.UserId = userId;

        _context.Add(heroDB);
        if (_context.SaveChanges() > 0)
        {
            return Ok();
        }

        throw new Exception("Failed to create hero");
    }
}