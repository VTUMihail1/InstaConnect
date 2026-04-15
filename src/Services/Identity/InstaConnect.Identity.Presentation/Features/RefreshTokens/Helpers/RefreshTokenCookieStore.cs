using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Helpers;

internal class RefreshTokenCookieStore : IRefreshTokenCookieStore
{
    private readonly ICookieStore _cookieStore;

    public RefreshTokenCookieStore(ICookieStore cookieStore)
    {
        _cookieStore = cookieStore;
    }

    public void Set(string id, string value, DateTimeOffset expiresAtUtc)
    {
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Id, id, expiresAtUtc);
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Value, value, expiresAtUtc);
    }

    public void Delete()
    {
        _cookieStore.Delete(RefreshTokenCookieKeys.Id);
        _cookieStore.Delete(RefreshTokenCookieKeys.Value);
    }
}
