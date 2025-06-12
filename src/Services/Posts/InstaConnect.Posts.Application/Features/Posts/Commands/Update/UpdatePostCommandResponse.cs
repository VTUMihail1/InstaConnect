namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record UpdatePostCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
