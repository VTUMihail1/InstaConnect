using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;

public record UserClaimFilteredCollectionWriteQuery(string userId)
    : FilteredCollectionWriteQuery<UserClaim>(uc => string.IsNullOrEmpty(userId) || uc.UserId == userId);
