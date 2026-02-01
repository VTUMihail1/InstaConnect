using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentAddedEventRequest(PostCommentEventRequest PostComment)
    : IEventRequest;
