namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeApiResponse(string Id, string LikeId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
