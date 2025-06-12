namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record UpdatePostResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
