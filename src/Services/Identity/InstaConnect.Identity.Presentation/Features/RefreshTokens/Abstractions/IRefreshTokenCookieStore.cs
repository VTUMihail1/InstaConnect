using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCookieStore
{
    void Set(RefreshTokenCookie cookie);

    void Delete();
}
