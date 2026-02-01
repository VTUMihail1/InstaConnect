namespace InstaConnect.Identity.Application.Features.RefreshTokens.Models;

public record AccessTokenCommandResponse(string Value, DateTimeOffset ExpiresAtUtc);
