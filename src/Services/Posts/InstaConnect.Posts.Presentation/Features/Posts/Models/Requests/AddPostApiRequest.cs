using InstaConnect.Posts.Presentation.Features.Posts.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record AddPostApiRequest(
	[UserIdFromClaim] string UserId,
	[FromBody] AddPostApiBody Body
);
