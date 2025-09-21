namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowByFollowerFilterQuery(
    string FollowerId,
    string FollowingName);
