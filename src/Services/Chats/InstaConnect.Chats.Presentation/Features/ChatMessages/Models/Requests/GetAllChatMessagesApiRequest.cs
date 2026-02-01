using System.Security.Claims;

using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] ChatMessageSortProperty SortTerm = ChatMessageDefaultValues.SortProperty,
    [FromQuery] int Page = ChatMessageDefaultValues.Page,
    [FromQuery] int PageSize = ChatMessageDefaultValues.PageSize) : ISortableApiRequest<ChatMessageSortProperty>, IPaginatableApiRequest;
