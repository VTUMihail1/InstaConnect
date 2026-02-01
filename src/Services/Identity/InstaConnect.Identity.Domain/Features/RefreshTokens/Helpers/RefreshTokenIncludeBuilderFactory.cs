namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeBuilderFactory : IRefreshTokenIncludeBuilderFactory
{
    public RefreshTokenIncludeBuilder Create()
    {
        return new RefreshTokenIncludeBuilder([]);
    }
}
