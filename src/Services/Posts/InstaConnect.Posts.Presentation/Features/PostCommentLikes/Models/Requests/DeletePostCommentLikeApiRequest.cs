namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record DeletePostCommentLikeApiRequest(
	[FromRoute] string Id,
	[FromRoute] string CommentId,
	[UserIdFromClaim] string UserId
);
