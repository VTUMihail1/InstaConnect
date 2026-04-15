namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCookieStore
{
    void Set(string id, string value, DateTimeOffset expiresAtUtc);

    void Delete();
}
