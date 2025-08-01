namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetAllPostCommentLikesQueryParameters(
    string Id,
    string CommentId,
    string UserId,
    string UserName,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
