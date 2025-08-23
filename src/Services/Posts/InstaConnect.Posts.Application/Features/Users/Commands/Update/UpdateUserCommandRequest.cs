using InstaConnect.Posts.Application.Features.Posts.Commands.Update;

namespace InstaConnect.Users.Application.Features.Users.Commands.Add;

public record UpdateUserCommandRequest(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImage) : ICommandRequest<UpdateUserCommandResponse>;
