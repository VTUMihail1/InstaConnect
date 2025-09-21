using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Models;
using InstaConnect.Users.Infrastructure.Features.Users.Models;

namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Utilities;

public static class RefreshTokenQuerySql
{
    public const string GetById = $@"SELECT
                                       rt.id AS {nameof(RefreshTokenQueryEntity.Id)},
                                       rt.value AS {nameof(RefreshTokenQueryEntity.Value)},
                                       rt.expires_at AS {nameof(RefreshTokenQueryEntity.ExpiresAt)},
                                       rt.created_at AS {nameof(RefreshTokenQueryEntity.CreatedAt)},
                                       rt.updated_at AS {nameof(RefreshTokenQueryEntity.UpdatedAt)},
                                   FROM refresh_tokens rt
                                   WHERE rt.{nameof(RefreshTokenQueryEntity.Id)} = @{nameof(GetRefreshTokenByIdQueryParameters.Id)}
                                   AND rt.{nameof(RefreshTokenQueryEntity.Value)} = @{nameof(GetRefreshTokenByIdQueryParameters.Value)};";
}
