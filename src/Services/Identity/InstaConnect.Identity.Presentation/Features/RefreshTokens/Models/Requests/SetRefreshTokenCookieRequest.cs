namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;

public record SetRefreshTokenCookieRequest(string Id, string Value, DateTimeOffset ExpiresAtUtc);
