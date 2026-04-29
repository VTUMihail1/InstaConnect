using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Posts.Events.Features.Posts;

public record PostEventRequest(
		string Id,
		string UserId,
		string Title,
		string Content,
		UserEventRequest User,
		DateTimeOffset CreatedAtUtc,
		DateTimeOffset UpdatedAtUtc);
