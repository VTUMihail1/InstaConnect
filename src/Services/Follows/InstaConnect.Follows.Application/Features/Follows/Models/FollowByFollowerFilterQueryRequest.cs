namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowerFilterQueryRequest(
    UserIdPayload FollowerId,
    NamePayload FollowingName);
