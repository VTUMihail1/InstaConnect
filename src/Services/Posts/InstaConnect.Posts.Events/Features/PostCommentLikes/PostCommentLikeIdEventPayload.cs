namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeIdEventPayload(PostCommentIdEventPayload CommentId, UserIdEventPayload UserId);
