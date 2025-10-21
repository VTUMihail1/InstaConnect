using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Helpers;

namespace InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeQueryBuilderFactory
{
    RefreshTokenIncludeQueryBuilder Create();
}