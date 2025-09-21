namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public record UpdateUserCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
