using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsForFollowerApiRequest(
    [FromRoute] string FollowerId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromQuery] string FollowingName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] FollowsForFollowerSortTerm SortTerm = FollowDefaultValues.ByFollowerSortProperty,
    [FromQuery] int Page = FollowDefaultValues.Page,
    [FromQuery] int PageSize = FollowDefaultValues.PageSize) : ISortableApiRequest<FollowsForFollowerSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
