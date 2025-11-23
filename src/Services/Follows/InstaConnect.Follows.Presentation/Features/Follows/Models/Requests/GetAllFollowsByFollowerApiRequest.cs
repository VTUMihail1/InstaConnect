using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowerApiRequest(
    [FromRoute] string FollowerId,
    [FromQuery] string FollowingName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] FollowByFollowerSortProperty SortProperty = FollowDefaultValues.ByFollowerSortProperty,
    [FromQuery] int Page = FollowDefaultValues.Page,
    [FromQuery] int PageSize = FollowDefaultValues.PageSize);
