namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record DeletePostCommentApiRequest(
	[FromRoute] string Id,
	[FromRoute] string CommentId,
	[UserIdFromClaim] string UserId
);
