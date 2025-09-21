using InstaConnect.Common.Models.Enums;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Models;

public record FollowByFollowerQuerySorting(
    SortOrder Order,
    FollowByFollowerSortProperty Property);
