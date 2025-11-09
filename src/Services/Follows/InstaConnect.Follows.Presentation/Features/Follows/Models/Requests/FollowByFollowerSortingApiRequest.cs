using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record FollowByFollowerSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] FollowByFollowerSortProperty Property = FollowByFollowerSortProperty.ByCreatedAt);
