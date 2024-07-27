using System.Linq.Expressions;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Data.Models.Filters;

public record UserClaimFilteredCollectionWriteQuery(string userId) 
    : FilteredCollectionWriteQuery<UserClaim>(uc => string.IsNullOrEmpty(userId) || uc.UserId == userId);
