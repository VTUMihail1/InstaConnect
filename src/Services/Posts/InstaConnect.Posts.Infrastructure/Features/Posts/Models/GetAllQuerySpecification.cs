namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetAllQuerySpecification(
    string Sql,
    GetAllQueryParameters Parameters);
