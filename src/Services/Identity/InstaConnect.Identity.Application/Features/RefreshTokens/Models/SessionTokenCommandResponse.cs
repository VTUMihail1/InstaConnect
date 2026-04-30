using InstaConnect.Common.Application.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Models;

public record SessionTokenCommandResponse(
	RefreshTokenIdCommandResponse Id,
	AccessTokenCommandResponse AccessToken,
	DateTimeOffset ExpiresAtUtc);
