using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsFilterQuery(
    UserId FollowerId,
    Name FollowingName);
