namespace InstaConnect.Identity.Application.Features.RefreshTokens.Models;

public record RefreshTokenCommandResponse(string Id, string Value, DateTimeOffset ExpiresAt);


