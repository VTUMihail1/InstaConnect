using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(this PostCommentLikeAddedEventRequest request, PostCommentLike entity)
    {
        return entity.Matches(request.PostCommentLike);
    }

    public static bool Matches(this PostCommentLikeDeletedEventRequest request, PostCommentLike entity)
    {
        return entity.Matches(request.PostCommentLike);
    }

    public static bool Matches(this PostCommentLikeEventRequest r, PostCommentLikeEventRequest request)
    {
        return r.Id == request.Id &&
               r.CommentId == request.CommentId &&
               r.UserId == request.UserId &&
               r.User.Matches(request.User) &&
               r.PostComment.Matches(request.PostComment) &&
               r.CreatedAtUtc == request.CreatedAtUtc;
    }

    public static bool Matches(this PostCommentLike entity, PostCommentLikeEventRequest request)
    {
        return entity.Id.Matches(request.Id, request.CommentId, request.UserId) &&
               entity.User != null && entity.User.Matches(request.User) &&
               entity.PostComment != null && entity.PostComment.Matches(request.PostComment) &&
               entity.CreatedAtUtc == request.CreatedAtUtc;
    }

    public static bool Matches(this PostCommentLikeId p, string id, string commentId, string userId)
    {
        return p.CommentId.Matches(id, commentId) &&
               p.UserId.Matches(userId);
    }
}
