using System.Linq.Expressions;

using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
public static class EmailConfirmationTokenFilterExtensions
{
    public static FilterDefinition<EmailConfirmationToken> GetFilter(this EmailConfirmationTokenId filter)
    {
        return filter.GetFilterForIdEquals<EmailConfirmationToken>(p => p.Id.Id.Id, p => p.Id.Value);
    }

    public static FilterDefinition<EmailConfirmationToken> GetFilter(this IEnumerable<EmailConfirmationTokenId> filter)
    {
        return filter.GetFilterForIdIn<EmailConfirmationToken>(p => p.Id.Id.Id, p => p.Id.Value);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(
        this EmailConfirmationTokenId filter,
        Expression<Func<T, object>> idField,
        Expression<Func<T, object>> valueField)
    {
        var id = filter.Id.GetFilterForIdEquals(idField);
        var value = Builders<T>.Filter.EqualsCaseInsensitive(valueField, filter.Value, filter.Value.IsNullOrEmptyOrWhiteSpace());

        return Builders<T>.Filter.And(id, value);
    }

    public static FilterDefinition<T> GetFilterForIdIn<T>(
        this IEnumerable<EmailConfirmationTokenId> filter,
        Expression<Func<T, object>> idField,
        Expression<Func<T, object>> valueField)
    {
        var id = filter.Select(a => a.Id).GetFilterForIdIn(idField);
        var value = Builders<T>.Filter.InCaseInsensitive(valueField, filter.Select(p => p.Value), filter.IsEmpty());

        return Builders<T>.Filter.And(id, value);
    }
}
