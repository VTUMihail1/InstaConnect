using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeAddedEventRequest(PostLikeEventRequest PostLike)
    : IEventRequest;
