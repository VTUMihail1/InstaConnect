namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Payloads;

public record PostCommentLikeIdApiPayload(PostCommentIdApiPayload CommentId, UserIdApiPayload UserId);
