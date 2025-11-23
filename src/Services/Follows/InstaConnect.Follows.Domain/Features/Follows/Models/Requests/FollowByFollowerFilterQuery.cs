namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowByFollowerFilterQuery(
    UserId FollowerId,
    Name FollowingName);
