using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(this PostCommentLikeAddedEventRequest request, PostCommentLike entity)
    {
        return entity.Id.Matches(request.Id, request.CommentId, request.UserId) &&
               entity.CreatedAtUtc == request.CreatedAtUtc;
    }

    public static bool Matches(this PostCommentLikeDeletedEventRequest request, PostCommentLike entity)
    {
        return entity.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this PostCommentLikeId p, string id, string commentId, string userId)
    {
        return p.CommentId.Matches(id, commentId) &&
               p.UserId.Matches(userId);
    }
}
