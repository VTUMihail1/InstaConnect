namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models;

public record RefreshTokenCookie(string Id, string Value, DateTimeOffset ExpiresAtUtc);
