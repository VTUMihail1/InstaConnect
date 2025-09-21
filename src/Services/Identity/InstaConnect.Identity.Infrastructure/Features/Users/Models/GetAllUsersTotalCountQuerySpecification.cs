using InstaConnect.Users.Domain.Features.Users.Models;

namespace InstaConnect.Users.Infrastructure.Features.Users.Models;

public record GetAllUsersTotalCountQuerySpecification(
    string Sql,
    GetAllUsersTotalCountQueryParameters Parameters);
