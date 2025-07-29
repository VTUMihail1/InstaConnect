namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;

public record GetPostCommentLikeByIdQuery(
    string Id,
    string CommentId,
    string CommentLikeId);
