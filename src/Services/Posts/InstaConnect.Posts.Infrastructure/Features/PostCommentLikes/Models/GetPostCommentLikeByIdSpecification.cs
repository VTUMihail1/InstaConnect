namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetPostCommentLikeByIdSpecification(
    string Sql,
    GetPostCommentLikeByIdQueryParameters Parameters);
