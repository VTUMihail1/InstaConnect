using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowingApiRequest(
    [FromRoute] string FollowingId,
    [FromQuery] string FollowerName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] FollowByFollowingSortProperty SortProperty = FollowDefaultValues.ByFollowingSortProperty,
    [FromQuery] int Page = FollowDefaultValues.Page,
    [FromQuery] int PageSize = FollowDefaultValues.PageSize) : ISortableApiRequest<FollowByFollowingSortProperty>, IPaginatableApiRequest;
