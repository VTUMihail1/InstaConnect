namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

public record GetPostCommentByIdQuerySpecification(
    string Sql,
    GetPostCommentByIdQueryParameters Parameters);
