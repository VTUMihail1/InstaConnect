namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowingQuerySpecification(
    string Sql,
    GetAllFollowsByFollowingQueryParameters Parameters);
