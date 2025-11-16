namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record AddPostCommentLikeCommand(PostCommentId CommentId, UserId UserId);
