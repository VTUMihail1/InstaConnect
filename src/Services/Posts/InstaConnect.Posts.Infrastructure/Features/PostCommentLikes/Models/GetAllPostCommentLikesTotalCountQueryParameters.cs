namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetAllPostCommentLikesTotalCountQueryParameters(
    string Id,
    string CommentId,
    string UserName);
