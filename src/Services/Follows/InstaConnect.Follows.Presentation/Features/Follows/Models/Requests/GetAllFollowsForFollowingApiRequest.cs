using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsForFollowingApiRequest(
    [FromRoute] string FollowingId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromQuery] string FollowerName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] FollowsForFollowingSortTerm SortTerm = FollowDefaultValues.ByFollowingSortProperty,
    [FromQuery] int Page = FollowDefaultValues.Page,
    [FromQuery] int PageSize = FollowDefaultValues.PageSize) : ISortableApiRequest<FollowsForFollowingSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
