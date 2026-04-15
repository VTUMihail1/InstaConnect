using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockFactory
{
    public static IRefreshTokenCookieStore CreateCookieStore()
    {
        return Mocker.Mock<IRefreshTokenCookieStore>();
    }
}
