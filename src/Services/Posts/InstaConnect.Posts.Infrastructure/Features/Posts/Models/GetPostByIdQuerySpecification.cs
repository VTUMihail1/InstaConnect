namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetPostByIdQuerySpecification(
    string Sql,
    GetPostByIdQueryParameters Parameters);
