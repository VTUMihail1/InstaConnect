using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this PostCommentAddedEventRequest request, PostComment entity)
    {
        return entity.Matches(request.PostComment);
    }

    public static bool Matches(this PostCommentUpdatedEventRequest request, PostComment entity)
    {
        return entity.Matches(request.PostComment);
    }

    public static bool Matches(this PostCommentDeletedEventRequest request, PostComment entity)
    {
        return entity.Matches(request.PostComment);
    }

    public static bool Matches(this PostCommentEventRequest r, PostCommentEventRequest request)
    {
        return r.Id == request.Id &&
               r.CommentId == request.CommentId &&
               r.UserId == request.UserId &&
               r.Content == request.Content &&
               r.User.Matches(request.User) &&
               r.Post.Matches(request.Post) &&
               r.CreatedAtUtc == request.CreatedAtUtc &&
               r.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this PostComment entity, PostCommentEventRequest request)
    {
        return entity.Id.Matches(request.Id, request.CommentId) &&
               entity.Content == request.Content &&
               entity.User != null && entity.User.Matches(request.User) &&
               entity.Post != null && entity.Post.Matches(request.Post) &&
               entity.CreatedAtUtc == request.CreatedAtUtc &&
               entity.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this PostCommentId p, string id, string commentId)
    {
        return p.Id.Matches(id) &&
               p.CommentId.EqualsOrdinalIgnoreCase(commentId);
    }
}
