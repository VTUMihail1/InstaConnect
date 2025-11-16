namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentIdEventPayload(PostIdEventPayload Id, string CommentId);
