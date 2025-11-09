namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record AddPostLikeApiResponse(string Id, string UserId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
