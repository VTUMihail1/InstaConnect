namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowerQuerySpecification(
    string Sql,
    GetAllFollowsByFollowerQueryParameters Parameters);
