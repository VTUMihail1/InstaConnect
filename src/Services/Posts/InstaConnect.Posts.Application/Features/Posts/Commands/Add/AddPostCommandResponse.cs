namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
