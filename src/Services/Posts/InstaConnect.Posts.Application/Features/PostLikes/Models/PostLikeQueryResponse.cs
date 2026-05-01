namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeQueryResponse(
	string Id,
	string UserId,
	UserQueryResponse? User,
	PostQueryResponse? Post,
	DateTimeOffset CreatedAtUtc);
