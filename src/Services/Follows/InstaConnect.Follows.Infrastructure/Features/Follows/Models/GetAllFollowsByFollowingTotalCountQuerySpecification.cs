namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowingTotalCountQuerySpecification(
    string Sql,
    GetAllFollowsByFollowingTotalCountQueryParameters Parameters);
