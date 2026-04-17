using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Data;
using VideoGameCQRS.Entities;
using VideoGameCQRS.Features.Player.CreatePlayer;

namespace VideoGameCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController(VideoGameAppDbContext context , ISender sender) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<int>> GetPlayers()
        {
            // Logic to retrieve players from the database
            var players = await context.Players.ToListAsync();
            return Ok(players);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePlayer(CreatePlayerCommand createPlayer)
        {
            // Logic to create a new player in the database
            var playerId = await sender.Send(createPlayer);
            return CreatedAtAction(nameof(GetPlayers), new { id = playerId }, playerId);
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
