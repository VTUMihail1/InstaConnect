using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this PostCommentAddedEventRequest request, PostComment entity)
    {
        return entity.Id.Matches(request.Id, request.CommentId) &&
               entity.UserId.Matches(request.UserId) &&
               entity.Content == request.Content &&
               entity.CreatedAtUtc == request.CreatedAtUtc &&
               entity.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this PostCommentUpdatedEventRequest request, PostComment entity)
    {
        return entity.Id.Matches(request.Id, request.CommentId) &&
               entity.UserId.Matches(request.UserId) &&
               entity.Content == request.Content &&
               entity.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this PostCommentDeletedEventRequest request, PostComment entity)
    {
        return entity.Id.Matches(request.Id, request.CommentId);
    }

    public static bool Matches(this PostCommentId p, string id, string commentId)
    {
        return p.Id.Matches(id) &&
               p.CommentId == commentId;
    }
}
