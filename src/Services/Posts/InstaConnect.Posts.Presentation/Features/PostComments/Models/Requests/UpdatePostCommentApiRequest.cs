using InstaConnect.Posts.Presentation.Features.PostComments.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record UpdatePostCommentApiRequest(
	[FromRoute] string Id,
	[FromRoute] string CommentId,
	[UserIdFromClaim] string UserId,
	[FromBody] UpdatePostCommentApiBody Body
);
