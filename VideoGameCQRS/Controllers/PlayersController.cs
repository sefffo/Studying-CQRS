using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Data;
using VideoGameCQRS.Entities;

namespace VideoGameCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController(VideoGameAppDbContext context) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<int>> GetPlayers()
        {
            // Logic to retrieve players from the database
            var players = await context.Players.ToListAsync();
            return Ok(players);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePlayer(Player player)
        {
            // Logic to create a new player in the database
            context.Players.Add(player);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlayers), new { id = player.Id }, player);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            // Logic to retrieve a player by ID from the database
            var player = await context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
    }
}
