using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Helpers;

internal class RefreshTokenCookieStore : IRefreshTokenCookieStore
{
    private readonly ICookieStore _cookieStore;

    public RefreshTokenCookieStore(ICookieStore cookieStore)
    {
        _cookieStore = cookieStore;
    }

    public void Set(RefreshTokenCookie cookie)
    {
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Id, cookie.Id, cookie.ExpiresAtUtc);
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Value, cookie.Value, cookie.ExpiresAtUtc);
    }

    public void Delete()
    {
        _cookieStore.Delete(RefreshTokenCookieKeys.Id);
        _cookieStore.Delete(RefreshTokenCookieKeys.Value);
    }
}
