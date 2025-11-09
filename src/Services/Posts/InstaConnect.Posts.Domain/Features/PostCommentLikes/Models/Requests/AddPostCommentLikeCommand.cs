namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record AddPostCommentLikeCommand(string Id, string CommentId, string UserId);
