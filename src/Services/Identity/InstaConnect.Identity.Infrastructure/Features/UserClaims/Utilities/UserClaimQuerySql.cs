using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Utilities;

public static class UserClaimQuerySql
{
    public const string GetAll = $@"SELECT 
                                       uc.id AS {nameof(UserClaimQueryEntity.Id)},
                                       uc.claim AS {nameof(UserClaimQueryEntity.Claim)},
                                       uc.value AS {nameof(UserClaimQueryEntity.Value)},
                                       uc.created_at AS {nameof(UserClaimQueryEntity.CreatedAt)},
                                       uc.updated_at AS {nameof(UserClaimQueryEntity.UpdatedAt)},
                                   FROM user_claims uc
                                   WHERE uc.{nameof(UserClaimQueryEntity.Id)} = @{nameof(GetAllUserClaimsQueryParameters.Id)};";
}
