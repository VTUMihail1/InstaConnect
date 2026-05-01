namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record DeletePostLikeApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string UserId
);
