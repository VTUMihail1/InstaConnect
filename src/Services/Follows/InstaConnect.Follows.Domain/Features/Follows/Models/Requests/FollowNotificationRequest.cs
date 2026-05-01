namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowNotificationRequest(
	string FollowerId,
	string FollowingId,
	UserNotificationRequest Follower,
	UserNotificationRequest Following,
	DateTimeOffset CreatedAtUtc);
