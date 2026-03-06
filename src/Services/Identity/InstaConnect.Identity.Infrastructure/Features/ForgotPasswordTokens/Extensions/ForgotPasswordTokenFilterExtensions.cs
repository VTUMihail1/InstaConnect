using System.Linq.Expressions;

using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenFilterExtensions
{
    extension(ForgotPasswordTokenId filter)
    {
        public FilterDefinition<ForgotPasswordToken> GetFilter()
        {
            return filter.GetFilterForIdEquals<ForgotPasswordToken>(p => p.Id.Id.Id, p => p.Id.Value);
        }

        public FilterDefinition<T> GetFilterForIdEquals<T>(
            Expression<Func<T, object>> idField,
            Expression<Func<T, object>> valueField)
        {
            var id = filter.Id.GetFilterForIdEquals(idField);
            var value = Builders<T>.Filter.EqualsCaseInsensitive(valueField, filter.Value, filter.Value.IsNullOrEmptyOrWhiteSpace());

            return Builders<T>.Filter.And(id, value);
        }
    }

    extension(IEnumerable<ForgotPasswordTokenId> filter)
    {
        public FilterDefinition<ForgotPasswordToken> GetFilter()
        {
            return filter.GetFilterForIdIn<ForgotPasswordToken>(p => p.Id.Id.Id, p => p.Id.Value);
        }

        public FilterDefinition<T> GetFilterForIdIn<T>(
            Expression<Func<T, object>> idField,
            Expression<Func<T, object>> valueField)
        {
            var id = filter.Select(a => a.Id).GetFilterForIdIn(idField);
            var value = Builders<T>.Filter.InCaseInsensitive(valueField, filter.Select(p => p.Value), filter.IsEmpty());

            return Builders<T>.Filter.And(id, value);
        }
    }
}
