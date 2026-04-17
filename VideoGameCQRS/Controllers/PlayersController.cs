using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Data;
using VideoGameCQRS.Entities;
using VideoGameCQRS.Features.Player.CreatePlayer;
using VideoGameCQRS.Features.Player.GetAllPlayers;
using VideoGameCQRS.Features.Player.GetPlayerById;

namespace VideoGameCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController(ISender sender) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<int>> GetPlayers()
        {
            // Logic to retrieve players from the database
            var players = await sender.Send(new GetPlayersQuery(0, string.Empty));
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
            var player = await sender.Send(new GetPlayerByIdQuery(id));
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
    }
}
