using MediatR;

namespace VideoGameCQRS.Features.Player.GetAllPlayers
{
    public record GetPlayersQuery(int Id, string Name) : IRequest<IEnumerable<VideoGameCQRS.Entities.Player>>;
}
