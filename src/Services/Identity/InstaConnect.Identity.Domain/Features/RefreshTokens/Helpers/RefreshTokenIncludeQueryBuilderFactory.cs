namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeQueryBuilderFactory : IRefreshTokenIncludeQueryBuilderFactory
{
    public RefreshTokenIncludeQueryBuilder Create()
    {
        return new RefreshTokenIncludeQueryBuilder([]);
    }
}
