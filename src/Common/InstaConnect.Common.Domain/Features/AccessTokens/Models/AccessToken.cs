namespace InstaConnect.Common.Domain.Features.AccessTokens.Models;

public record AccessToken(
	string Value,
	DateTimeOffset ExpiresAtUtc);
