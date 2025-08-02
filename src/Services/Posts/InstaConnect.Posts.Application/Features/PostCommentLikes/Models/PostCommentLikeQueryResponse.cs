namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryResponse(string Id, string CommentId, string CommentLikeId, PostCommentLikeUserQueryResponse User);
