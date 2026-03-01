using System.Linq.Expressions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;
public static class UserFilterExtensions
{
    public static FilterDefinition<User> GetFilter(this UsersFilterQuery filter)
    {
        var name = filter.Name.GetFilterForNameStartsWith<User>(p => p.Name.Value);
        var firstName = Builders<User>.Filter.StartsWithCaseInsensitive(
            p => p.FirstName, filter.FirstName, filter.FirstName.IsNullOrEmptyOrWhiteSpace());
        var lastName = Builders<User>.Filter.StartsWithCaseInsensitive(
            p => p.LastName, filter.LastName, filter.LastName.IsNullOrEmptyOrWhiteSpace());

        return Builders<User>.Filter.And(name, firstName, lastName);
    }

    public static FilterDefinition<User> GetFilter(this UserId filter)
    {
        return filter.GetFilterForIdEquals<User>(p => p.Id.Id);
    }

    public static FilterDefinition<User> GetFilter(this Name filter)
    {
        return filter.GetFilterForNameEquals<User>(p => p.Name.Value);
    }

    public static FilterDefinition<User> GetFilter(this Email filter)
    {
        return filter.GetFilterForEmailEquals<User>(p => p.Email.Value);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(this UserId filter, Expression<Func<T, object>> idField)
    {
        return Builders<T>.Filter.EqualsCaseInsensitive(idField, filter.Id, filter.Id.IsEmpty());
    }

    public static FilterDefinition<T> GetFilterForIdIn<T>(
        this IEnumerable<UserId> filter, Expression<Func<T, object>> idField)
    {
        return Builders<T>.Filter.InCaseInsensitive(idField, filter.Select(p => p.Id), filter.IsEmpty());
    }
}
