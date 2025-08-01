namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetPostCommentLikeByIdAndUserIdQuerySpecification(
    string Sql,
    GetPostCommentLikeByIdAndUserIdQueryParameters Parameters);
