namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetFollowByIdQuerySpecification(
    string Sql,
    GetFollowByIdQueryParameters Parameters);
