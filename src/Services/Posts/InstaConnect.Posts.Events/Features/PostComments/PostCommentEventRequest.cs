using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentEventRequest(
        string Id,
        string CommentId,
        string UserId,
        string Content,
        UserEventRequest User,
        PostEventRequest Post,
        DateTimeOffset CreatedAtUtc,
        DateTimeOffset UpdatedAtUtc);
