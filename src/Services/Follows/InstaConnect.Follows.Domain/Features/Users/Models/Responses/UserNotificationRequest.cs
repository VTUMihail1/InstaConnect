namespace InstaConnect.Follows.Domain.Features.Users.Models.Responses;

public record UserNotificationRequest(
	string Id,
	string Name,
	string Email,
	string FirstName,
	string LastName,
	string? ProfileImageUrl,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
