using InstaConnect.Posts.Presentation.Features.PostComments.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record AddPostCommentApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string UserId,
	[FromBody] AddPostCommentApiBody Body
);
