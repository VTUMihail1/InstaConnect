using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Models;

public record FollowByFollowingQuerySorting(
    SortOrder Order,
    FollowByFollowingSortProperty Property);
