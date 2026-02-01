using System.Linq.Expressions;

using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class PostCommentFilterExtensions
{
    public static FilterDefinition<PostComment> GetFilter(this PostCommentsFilterQuery filter)
    {
        var id = filter.Id.GetFilterForIdEquals<PostComment>(p => p.Id.Id.Id);
        var userName = filter.UserName.GetFilterForNameStartsWith<PostComment>(p => p.User!.Name.Value);

        return Builders<PostComment>.Filter.And(id, userName);
    }

    public static FilterDefinition<PostComment> GetFilter(this PostCommentsForUserFilterQuery filter)
    {
        return filter.UserId.GetFilterForIdEquals<PostComment>(p => p.UserId.Id);
    }

    public static FilterDefinition<PostComment> GetFilter(this PostCommentId filter)
    {
        return filter.GetFilterForIdEquals<PostComment>(p => p.Id.Id.Id, p => p.Id.CommentId);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(
        this PostCommentId filter,
        Expression<Func<T, object>> idField,
        Expression<Func<T, object>> commentIdField)
    {
        var id = filter.Id.GetFilterForIdEquals(idField);
        var commentId = Builders<T>.Filter.EqualsCaseInsensitive(
            commentIdField, filter.CommentId, filter.CommentId.IsNullOrEmptyOrWhiteSpace());

        return Builders<T>.Filter.And(id, commentId);
    }
}
