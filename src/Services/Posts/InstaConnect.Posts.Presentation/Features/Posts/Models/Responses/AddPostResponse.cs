namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
