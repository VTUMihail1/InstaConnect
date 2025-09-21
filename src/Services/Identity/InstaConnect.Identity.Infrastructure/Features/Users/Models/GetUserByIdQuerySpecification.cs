namespace InstaConnect.Users.Infrastructure.Features.Users.Models;

public record GetUserByIdQuerySpecification(
    string Sql,
    GetUserByIdQueryParameters Parameters);
