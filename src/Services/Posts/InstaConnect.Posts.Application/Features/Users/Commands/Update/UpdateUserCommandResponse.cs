namespace InstaConnect.Posts.Application.Features.Users.Commands.Update;

public record UpdateUserCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
