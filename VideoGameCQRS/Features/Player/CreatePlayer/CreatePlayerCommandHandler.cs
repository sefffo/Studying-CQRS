using MediatR;
using VideoGameCQRS.Data;
using VideoGameCQRS.Entities;

namespace VideoGameCQRS.Features.Player.CreatePlayer
{
    public class CreatePlayerCommandHandler(VideoGameAppDbContext context) : IRequestHandler<CreatePlayerCommand, int>
    {
        //private readonly VideoGameAppDbContext _context = context;

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            // Logic to create a player and return the player's ID


            var player = new Player
            {
                Name = request.Name,
                Level = request.Level
            };


            await context.Players.Add(player);
            await context.SaveChangesAsync(cancellationToken);
            return player.Id;
        }
    }
}
