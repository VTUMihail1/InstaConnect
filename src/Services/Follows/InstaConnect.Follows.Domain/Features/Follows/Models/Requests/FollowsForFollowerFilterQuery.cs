namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsForFollowerFilterQuery(
    UserId FollowerId,
    Name FollowingName);
