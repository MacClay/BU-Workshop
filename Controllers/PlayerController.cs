using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Models;
using dotnetRPG.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnetRPG.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PlayerController : ControllerBase
    {
        public IPlayer repo;

        public PlayerController(IPlayer repo)
        {
            this.repo = repo;
        }
        [HttpGet("players")]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await repo.GetPlayers();
              return Ok(players);
        }
        [HttpGet("player/{id}")]
        public async Task<IActionResult> GetPlayer(Guid id)
        {
            var player = await repo.GetPlayers();
              return Ok(player);
        }
        [HttpPost("player")]
        public async Task<IActionResult> AddPlayers(Player player)
        {
            await repo.CreatePlayer(player);
            return Created("/",player);

        }
        [HttpPatch("player")]
        public async Task<IActionResult> UpdatePlayer(Guid id,Player player)
        {
            await repo.UpdatePlayer(id,player);
            return NoContent();
        }
    }
}