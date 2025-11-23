namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowingFilterQueryRequest(
    UserIdPayload FollowingId,
    NamePayload FollowerName);
