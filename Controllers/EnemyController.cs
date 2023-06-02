
using DuckGame.Data;
using DuckGame.Models.PlayerInfo;
using Microsoft.AspNetCore.Mvc;

namespace DuckGame.Conrollers;

            
    [ApiController]
    [Route("[controller]")]
    public class EnemyController: ControllerBase
    {
        private readonly DataContextEntity _context;

        public EnemyController(DataContextEntity context)
        {
            _context = context;
        }

        [HttpGet("/lowtier")]
        public IActionResult GetLowTierEnemy() 
        {
            Random random = new Random();
            var enemies = _context.Enemies.Where(tier => tier.EnemyType =="Low-tier").ToList();
            var ranEnemy = random.Next(enemies.Count());
            return Ok(enemies[ranEnemy]);
        }

        [HttpGet("/hightier")]
        public IActionResult GetHighTierEnemy() 
        {
            Random random = new Random();
            var enemies = _context.Enemies.Where(tier => tier.EnemyType =="High-tier").ToList();
            var ranEnemy = random.Next(enemies.Count());
            return Ok(enemies[ranEnemy]);
        }

        [HttpGet("/bosstier")]
        public IActionResult GetBossTierEnemy() 
        {
            Random random = new Random();
            var enemies = _context.Enemies.Where(tier => tier.EnemyType =="Boss-tier").ToList();
            var ranEnemy = random.Next(enemies.Count());
            return Ok(enemies[ranEnemy]);
        }
    }
