namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;

public record SetRefreshTokenCookieApiRequest(string Id, string Value, DateTimeOffset ExpiresAtUtc);
