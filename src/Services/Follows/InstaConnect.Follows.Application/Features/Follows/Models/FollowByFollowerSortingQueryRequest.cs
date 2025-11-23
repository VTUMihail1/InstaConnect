using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowerSortingQueryRequest(
    CommonSortOrder Order,
    FollowByFollowerSortProperty Property);
