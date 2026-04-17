using MediatR;

namespace VideoGameCQRS.Features.Player.GetPlayerById
{
    public record GetPlayerByIdQuery(int Id) : IRequest<VideoGameCQRS.Entities.Player>;
}
