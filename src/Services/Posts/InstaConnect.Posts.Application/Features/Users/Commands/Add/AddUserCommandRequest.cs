namespace InstaConnect.Posts.Application.Features.Users.Commands.Add;

public record AddUserCommandRequest(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImageUrl,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc) : ICommandRequest<AddUserCommandResponse>;
