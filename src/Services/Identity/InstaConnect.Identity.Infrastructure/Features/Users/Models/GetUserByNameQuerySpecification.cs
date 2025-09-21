namespace InstaConnect.Users.Infrastructure.Features.Users.Models;

public record GetUserByNameQuerySpecification(
    string Sql,
    GetUserByNameQueryParameters Parameters);
