using System.Linq.Expressions;

using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
public static class PostCommentFilterExtensions
{
    public static FilterDefinition<PostComment> GetFilter(this PostCommentFilterQuery filter)
    {
        var id = filter.Id.GetFilterForIdEquals<PostComment>(p => p.Id.Id.Id);
        var userName = filter.UserName.GetFilterForNameStartsWith<PostComment>(p => p.User!.Name.Value);

        return Builders<PostComment>.Filter.And(id, userName);
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
