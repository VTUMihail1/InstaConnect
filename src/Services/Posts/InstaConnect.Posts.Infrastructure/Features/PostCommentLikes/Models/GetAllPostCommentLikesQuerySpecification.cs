namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetAllPostCommentLikesQuerySpecification(
    string Sql,
    GetAllPostCommentLikesQueryParameters Parameters);
