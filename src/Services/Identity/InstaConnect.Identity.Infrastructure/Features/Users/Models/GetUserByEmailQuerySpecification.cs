namespace InstaConnect.Users.Infrastructure.Features.Users.Models;

public record GetUserByEmailQuerySpecification(
    string Sql,
    GetUserByEmailQueryParameters Parameters);
