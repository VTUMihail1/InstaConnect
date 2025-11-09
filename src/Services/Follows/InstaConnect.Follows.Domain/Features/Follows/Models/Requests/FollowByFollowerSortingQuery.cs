using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowByFollowerSortingQuery(
    SortOrder Order,
    FollowByFollowerSortProperty Property);
