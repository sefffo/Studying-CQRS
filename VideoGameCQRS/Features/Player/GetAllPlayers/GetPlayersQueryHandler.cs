using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Data;

namespace VideoGameCQRS.Features.Player.GetAllPlayers
{
    public class GetPlayersQueryHandler(VideoGameAppDbContext context) : IRequestHandler<GetPlayersQuery, IEnumerable<VideoGameCQRS.Entities.Player>>
    {
        public async Task<IEnumerable<Entities.Player>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var Players = await context.Players.ToListAsync(cancellationToken);
            if(Players == null || !Players.Any())
            {
                throw new Exception("No players found.");
            }
            return Players;
        }
    }
}
