namespace InstaConnect.Chats.Application.Features.Users.Commands.Update;

public record UpdateUserCommandRequest(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImage) : ICommandRequest<UpdateUserCommandResponse>;
