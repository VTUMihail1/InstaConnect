namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostApiResponse(
	string Id,
	string UserId,
	string Title,
	string Content,
	UserApiResponse? User,
	bool IsLikedByCurrentUser,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
