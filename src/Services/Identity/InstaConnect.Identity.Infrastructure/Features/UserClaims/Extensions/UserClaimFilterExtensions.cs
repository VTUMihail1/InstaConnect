using System.Linq.Expressions;

using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

public static class UserClaimFilterExtensions
{
    extension(UserClaimsFilterQuery filter)
    {
        public FilterDefinition<UserClaim> GetFilter()
        {
            return filter.Id.GetFilterForIdEquals<UserClaim>(p => p.Id.Id.Id);
        }
    }

    extension(UserClaimId filter)
    {
        public FilterDefinition<UserClaim> GetFilter()
        {
            return filter.GetFilterForIdEquals<UserClaim>(p => p.Id.Id.Id);
        }

        public FilterDefinition<T> GetFilterForIdEquals<T>(Expression<Func<T, object>> idField)
        {
            return Builders<T>.Filter.EqualsCaseInsensitive(idField, filter.Id, filter.Id.Id.IsEmpty());
        }
    }

    extension(UserClaimId filter)
    {
        public FilterDefinition<T> GetFilterForIdEquals<T>(
            Expression<Func<T, object>> idField,
            Expression<Func<T, object>> claimField)
        {
            var id = filter.Id.GetFilterForIdEquals(idField);
            var value = Builders<T>.Filter.EqualsCaseInsensitive(claimField, filter.Claim, filter.Claim.IsEmpty());

            return Builders<T>.Filter.And(id, value);
        }
    }
}
