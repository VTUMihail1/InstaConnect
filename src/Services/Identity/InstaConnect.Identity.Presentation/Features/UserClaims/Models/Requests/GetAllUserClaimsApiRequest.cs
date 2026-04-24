using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;

public record GetAllUserClaimsApiRequest(
    [FromRoute] string Id,
    [UserIdFromClaim] string CurrentId,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] UserClaimsSortTerm SortTerm = UserClaimDefaultValues.SortTerm,
    [FromQuery] int Page = UserClaimDefaultValues.Page,
    [FromQuery] int PageSize = UserClaimDefaultValues.PageSize) : ISortableApiRequest<UserClaimsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
