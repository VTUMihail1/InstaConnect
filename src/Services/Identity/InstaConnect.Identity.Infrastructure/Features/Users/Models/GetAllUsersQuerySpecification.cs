namespace InstaConnect.Users.Infrastructure.Features.Users.Models;

public record GetAllUsersQuerySpecification(
    string Sql,
    GetAllUsersQueryParameters Parameters);
