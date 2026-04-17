using MediatR;

namespace VideoGameCQRS.Features.Player.CreatePlayer
{

    //IRequest<T> is an interface from the MediatR library that represents a request that expects a response of type T. In this case, CreatePlayerCommand implements IRequest<int>,
    //which means that when this command is handled, it will return an integer value (likely the ID of the newly created player).
    //Acts like a DTO (Data Transfer Object) that encapsulates the data needed to create a new player. It can include properties such as the player's name, age, etc.
    //, which will be used by the command handler to perform the creation logic.
    public record CreatePlayerCommand(string Name, int Level) : IRequest<int>;
}
