namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record PostLikeApiResponse(PostLikeIdApiPayload Id, UserApiResponse User, DateTimeOffset CreatedAtUtc);
