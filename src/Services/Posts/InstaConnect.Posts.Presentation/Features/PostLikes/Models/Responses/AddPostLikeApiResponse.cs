namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeApiResponse(string Id, string UserId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
