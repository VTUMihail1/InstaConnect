namespace InstaConnect.Follows.Application.Features.Users.Commands.Add;

public record AddUserCommandRequest(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImage) : ICommandRequest<AddUserCommandResponse>;
