namespace InstaConnect.Identity.Application.Features.RefreshTokens.Models;

public record AccessTokenCommandResponse(string Id, string Value, DateTimeOffset ExpiresAt);
