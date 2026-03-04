using System.Security.Claims;

using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Chats.Presentation.Features.Users.Utilities;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record GetAllChatsApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromRoute] string ParticipantOneId,
    [FromQuery] string ParticipantTwoName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] ChatsSortTerm SortTerm = ChatDefaultValues.SortTerm,
    [FromQuery] int Page = ChatDefaultValues.Page,
    [FromQuery] int PageSize = ChatDefaultValues.PageSize) : ISortableApiRequest<ChatsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
