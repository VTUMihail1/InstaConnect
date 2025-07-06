namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public record UpdatePostCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
