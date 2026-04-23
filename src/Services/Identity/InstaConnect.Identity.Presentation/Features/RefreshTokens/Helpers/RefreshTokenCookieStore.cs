using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Helpers;

internal class RefreshTokenCookieStore : IRefreshTokenCookieStore
{
    private readonly ICookieStore _cookieStore;

    public RefreshTokenCookieStore(ICookieStore cookieStore)
    {
        _cookieStore = cookieStore;
    }

    public void Set(SetRefreshTokenCookieRequest request)
    {
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Id, request.Id, request.ExpiresAtUtc);
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Value, request.Value, request.ExpiresAtUtc);
    }

    public void Delete()
    {
        _cookieStore.Delete(RefreshTokenCookieKeys.Id);
        _cookieStore.Delete(RefreshTokenCookieKeys.Value);
    }
}
