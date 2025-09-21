namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetUserByNameSpecification(
    string Sql,
    GetUserByNameParameters Parameters);
