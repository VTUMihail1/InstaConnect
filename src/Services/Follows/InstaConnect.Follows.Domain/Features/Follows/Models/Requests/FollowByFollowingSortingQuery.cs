using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowByFollowingSortingQuery(
    SortOrder Order,
    FollowByFollowingSortProperty Property);
