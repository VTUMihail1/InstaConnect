using System.Linq.Expressions;

using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
public static class RefreshTokenFilterExtensions
{
    public static FilterDefinition<RefreshToken> GetFilter(this RefreshTokenId filter)
    {
        return filter.GetFilterForIdEquals<RefreshToken>(p => p.Id.Id.Id, p => p.Id.Value);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(
        this RefreshTokenId filter,
        Expression<Func<T, object>> idField,
        Expression<Func<T, object>> valueField)
    {
        var id = filter.Id.GetFilterForIdEquals(idField);
        var value = Builders<T>.Filter.EqualsCaseInsensitive(valueField, filter.Value, filter.Value.IsNullOrEmptyOrWhiteSpace());

        return Builders<T>.Filter.And(id, value);
    }
}
