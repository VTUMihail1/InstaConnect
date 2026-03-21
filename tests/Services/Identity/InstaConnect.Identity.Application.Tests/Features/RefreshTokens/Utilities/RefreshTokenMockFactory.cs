namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockFactory
{
    public static IRefreshTokenCommandService CreateCommandService()
    {
        return Mocker.Mock<IRefreshTokenCommandService>();
    }
}
