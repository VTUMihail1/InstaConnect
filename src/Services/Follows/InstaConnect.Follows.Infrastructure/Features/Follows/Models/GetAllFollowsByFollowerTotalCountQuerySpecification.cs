using InstaConnect.Follows.Domain.Features.Follows.Models;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowerTotalCountQuerySpecification(
    string Sql,
    GetAllFollowsByFollowerTotalCountQueryParameters Parameters);
