using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Abstractions;

namespace InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeQueryBuilderFactory : IRefreshTokenIncludeQueryBuilderFactory
{
    public RefreshTokenIncludeQueryBuilder Create()
    {
        return new RefreshTokenIncludeQueryBuilder([]);
    }
}
