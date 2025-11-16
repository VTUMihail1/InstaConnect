using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowByFollowingSortingQuery(
    CommonSortOrder Order,
    FollowByFollowingSortProperty Property);
