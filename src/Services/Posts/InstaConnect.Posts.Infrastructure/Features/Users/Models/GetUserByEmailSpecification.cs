namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetUserByEmailSpecification(
    string Sql,
    GetUserByEmailParameters Parameters);
