using Microsoft.AspNetCore.Mvc;
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using DuckGame.DTO;
using AutoMapper;
using Newtonsoft;
using System.Text.Json;

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

    [HttpPost("{userId}/createhero")]
    [Produces("application/json")]
    public IActionResult CreateNewHero(int userId, [FromBody] HeroDTO heroDTO)
    {
        // String.Format('{0:f}', dt);
        // string jsonBody = Request.Body;
        Hero heroDB = _mapper.Map<Hero>(heroDTO);
        heroDB.UserId = userId;
        heroDB.HeroName = heroDTO.HeroName;
        heroDB.Class = heroDTO.Class;
        heroDB.DateLastPlayed = DateTime.Now;

        // string jsonBody = JsonSerializer.Serialize(heroDB);


        _context.Add(heroDB);
        if (_context.SaveChanges() > 0)
        {
            // return Ok($"{heroDB.Class} {heroDB.HeroName} Created successfully");
            return Ok(heroDB);
        }

        throw new Exception("Failed to create hero");
    }

    [HttpPatch("{userId}/hero/{heroId}/savehero")]
    public IActionResult SaveHero(int userId, int heroId, [FromBody] HeroDTO heroUpdateBody)
    {
        Hero heroDBExist = _context.Heroes.Find(heroId);

        if (heroDBExist != null)
        {
            // heroDBExist = _mapper.Map<Hero>(heroUpdateBody);
            heroDBExist.UserId = userId;
            heroDBExist.HeroName = heroUpdateBody.HeroName;
            heroDBExist.Class = heroUpdateBody.Class;
            heroDBExist.HeroLevel = heroUpdateBody.HeroLevel;
            heroDBExist.TotalHealth = heroUpdateBody.TotalHealth;
            heroDBExist.CurrentHealth = heroUpdateBody.CurrentHealth;
            heroDBExist.TotalAttack = heroUpdateBody.TotalAttack;
            heroDBExist.TotalDefense = heroUpdateBody.TotalAttack;
            heroDBExist.TotalBattles = heroUpdateBody.TotalBattles;
            heroDBExist.BattlesWon = heroUpdateBody.BattlesWon;
            heroDBExist.Deaths = heroUpdateBody.Deaths;
            heroDBExist.Coins = heroUpdateBody.Coins;
            heroDBExist.TotalEquippedWeaponSize = heroUpdateBody.TotalEquippedWeaponSize;
            heroDBExist.TotalEquippedArmorSize = heroUpdateBody.TotalEquippedArmorSize;
            heroDBExist.EquippedWeaponId1 = heroUpdateBody.EquippedWeaponId1;
            heroDBExist.EquippedWeaponId2 = heroUpdateBody.EquippedWeaponId2;
            heroDBExist.EquippedArmorId1 = heroUpdateBody.EquippedArmorId1;
            heroDBExist.EquippedArmorId2 = heroUpdateBody.EquippedArmorId2;
            heroDBExist.EquippedArmorId3 = heroUpdateBody.EquippedArmorId3;
            heroDBExist.CurrentZone = heroUpdateBody.CurrentZone;
            heroDBExist.CurrentNode = heroUpdateBody.CurrentNode;
            heroDBExist.DateLastPlayed = DateTime.Now;

            // heroDBExist.DateLastPlayed = DateTime.Now;
            if ( _context.SaveChanges() > 0)
            {
                return Ok("Saved Successfully");
            }
        }
        throw new Exception("Failed to save hero");
    }
}