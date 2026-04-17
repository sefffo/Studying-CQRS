using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Data;

namespace VideoGameCQRS.Features.Player.GetPlayerById
{
    public class GetPlayerByIdQueryHandler(VideoGameAppDbContext context) : IRequestHandler<GetPlayerByIdQuery, VideoGameCQRS.Entities.Player>
    {
        public async Task<Entities.Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await context.Players.FirstOrDefaultAsync(player=>player.Id==request.Id);
            if (player == null)
            {
                throw new KeyNotFoundException($"Player with ID {request.Id} not found.");
            }

            return player;
        }
    }
}
