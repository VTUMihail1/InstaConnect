using InstaConnect.Posts.Presentation.Features.Posts.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record UpdatePostApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string UserId,
	[FromBody] UpdatePostApiBody Body
);
