using System.Linq.Expressions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class UserFilterExtensions
{
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
}
