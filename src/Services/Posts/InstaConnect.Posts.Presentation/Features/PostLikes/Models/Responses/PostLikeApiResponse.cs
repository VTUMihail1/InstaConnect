namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record PostLikeApiResponse(
	string Id,
	string UserId,
	UserApiResponse? User,
	PostApiResponse? Post,
	DateTimeOffset CreatedAtUtc);
