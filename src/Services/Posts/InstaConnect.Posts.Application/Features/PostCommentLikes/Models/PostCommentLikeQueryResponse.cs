namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryResponse(
	string Id,
	string CommentId,
	string UserId,
	UserQueryResponse? User,
	PostCommentQueryResponse? PostComment,
	DateTimeOffset CreatedAtUtc);
