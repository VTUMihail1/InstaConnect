using System.Linq.Expressions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
public static class PostFilterExtensions
{
    public static FilterDefinition<Post> GetFilter(this PostFilterQuery filter)
    {
        var userName = filter.UserName.GetFilterForNameStartsWith<Post>(p => p.User!.Name.Value);
        var title = Builders<Post>.Filter.StartsWithCaseInsensitive(
            p => p.Title, filter.Title, filter.Title.IsNullOrEmptyOrWhiteSpace());

        return Builders<Post>.Filter.And(userName, title);
    }

    public static FilterDefinition<Post> GetFilter(this PostId filter)
    {
        return filter.GetFilterForIdEquals<Post>(p => p.Id.Id);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(this PostId filter, Expression<Func<T, object>> idField)
    {
        return Builders<T>.Filter.EqualsCaseInsensitive(idField, filter.Id, filter.Id.IsEmpty());
    }
}
