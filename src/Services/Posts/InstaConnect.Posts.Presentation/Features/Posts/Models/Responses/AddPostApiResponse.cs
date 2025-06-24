namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostApiResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
