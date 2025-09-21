namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeApiResponse(string Id, string CommentId, PostCommentLikeUserApiResponse User);
