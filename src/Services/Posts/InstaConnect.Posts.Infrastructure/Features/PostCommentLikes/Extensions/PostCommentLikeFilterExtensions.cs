using System.Linq.Expressions;

using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class PostCommentLikeFilterExtensions
{
    public static FilterDefinition<PostCommentLike> GetFilter(this PostCommentLikesFilterQuery filter)
    {
        var commentId = filter.CommentId.GetFilterForIdEquals<PostCommentLike>(p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId);
        var userName = filter.UserName.GetFilterForNameStartsWith<PostCommentLike>(p => p.User!.Name.Value);

        return Builders<PostCommentLike>.Filter.And(commentId, userName);
    }

    public static FilterDefinition<PostCommentLike> GetFilter(this PostCommentLikesForUserFilterQuery filter)
    {
        return filter.UserId.GetFilterForIdEquals<PostCommentLike>(p => p.Id.UserId.Id);
    }

    public static FilterDefinition<PostCommentLike> GetFilter(this PostCommentLikeId filter)
    {
        return filter.GetFilterForIdEquals<PostCommentLike>(
            p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId, p => p.Id.UserId.Id);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(
        this PostCommentLikeId filter,
        Expression<Func<T, object>> idField,
        Expression<Func<T, object>> commentIdField,
        Expression<Func<T, object>> userIdField)
    {
        var commentId = filter.CommentId.GetFilterForIdEquals(idField, commentIdField);
        var userId = filter.UserId.GetFilterForIdEquals(userIdField);

        return Builders<T>.Filter.And(commentId, userId);
    }
}
