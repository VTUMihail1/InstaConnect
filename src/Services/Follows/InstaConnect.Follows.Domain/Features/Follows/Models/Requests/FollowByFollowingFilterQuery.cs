namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowByFollowingFilterQuery(
    string FollowingId,
    string FollowerName);
