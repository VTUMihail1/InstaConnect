using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeDeletedEventRequest(PostLikeEventRequest PostLike)
    : IEventRequest;
