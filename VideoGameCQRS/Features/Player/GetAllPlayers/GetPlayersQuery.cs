using MediatR;

namespace VideoGameCQRS.Features.Player.GetAllPlayers
{
    public record GetPlayersQuery() : IRequest<IEnumerable<VideoGameCQRS.Entities.Player>>;
}
