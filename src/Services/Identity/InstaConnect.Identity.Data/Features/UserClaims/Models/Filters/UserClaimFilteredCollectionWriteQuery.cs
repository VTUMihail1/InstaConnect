using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;

public record UserClaimFilteredCollectionWriteQuery(string UserId)
    : FilteredCollectionWriteQuery<UserClaim>(uc => string.IsNullOrEmpty(UserId) || uc.UserId.Equals(UserId));
