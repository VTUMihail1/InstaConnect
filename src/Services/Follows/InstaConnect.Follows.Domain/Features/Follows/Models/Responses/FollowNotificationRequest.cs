using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

public record FollowNotificationRequest(
	string FollowerId,
	string FollowingId,
	UserNotificationRequest Follower,
	UserNotificationRequest Following,
	DateTimeOffset CreatedAtUtc);
