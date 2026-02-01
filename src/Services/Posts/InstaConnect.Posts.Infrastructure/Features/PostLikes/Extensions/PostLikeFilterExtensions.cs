using System.Linq.Expressions;

using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class PostLikeFilterExtensions
{
    public static FilterDefinition<PostLike> GetFilter(this PostLikesFilterQuery filter)
    {
        var id = filter.Id.GetFilterForIdEquals<PostLike>(p => p.Id.Id.Id);
        var userName = filter.UserName.GetFilterForNameStartsWith<PostLike>(p => p.User!.Name.Value);

        return Builders<PostLike>.Filter.And(id, userName);
    }

    public static FilterDefinition<PostLike> GetFilter(this PostLikesForUserFilterQuery filter)
    {
        return filter.UserId.GetFilterForIdEquals<PostLike>(p => p.Id.UserId.Id);
    }

    public static FilterDefinition<PostLike> GetFilter(this PostLikeId filter)
    {
        return filter.GetFilterForIdEquals<PostLike>(p => p.Id.Id.Id, p => p.Id.UserId.Id);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(
        this PostLikeId filter,
        Expression<Func<T, object>> idField,
        Expression<Func<T, object>> userIdField)
    {
        var id = filter.Id.GetFilterForIdEquals(idField);
        var userId = filter.UserId.GetFilterForIdEquals(userIdField);

        return Builders<T>.Filter.And(id, userId);
    }
}
