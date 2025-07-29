namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetAllPostsQuerySpecification(
    string Sql,
    GetAllPostsQueryParameters Parameters);
