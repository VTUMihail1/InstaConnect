using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record FollowByFollowerSortingApiRequest(
    [FromQuery(Name = "sortOrder")] CommonSortOrder Order = CommonSortOrder.ASC,
    [FromQuery(Name = "sortProperty")] FollowByFollowerSortProperty Property = FollowByFollowerSortProperty.ByCreatedAt);
