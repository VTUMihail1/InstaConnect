namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetPostCommentLikeByIdQuerySpecification(
    string Sql,
    GetPostCommentLikeByIdQueryParameters Parameters);
