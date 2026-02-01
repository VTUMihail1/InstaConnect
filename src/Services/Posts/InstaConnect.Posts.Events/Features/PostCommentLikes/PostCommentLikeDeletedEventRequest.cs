using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeDeletedEventRequest(PostCommentLikeEventRequest PostCommentLike)
    : IEventRequest;
