namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record UserNotificationRequest(
	string Id,
	string Name,
	string Email,
	string FirstName,
	string LastName,
	string? ProfileImageUrl,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
