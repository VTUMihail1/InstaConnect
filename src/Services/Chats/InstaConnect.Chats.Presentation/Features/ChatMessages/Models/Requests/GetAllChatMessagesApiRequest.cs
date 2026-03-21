using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesApiRequest(
    [UserIdFromClaim] string CurrentUserId,
    [UserIdFromClaim] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] ChatMessagesSortTerm SortTerm = ChatMessageDefaultValues.SortTerm,
    [FromQuery] int Page = ChatMessageDefaultValues.Page,
    [FromQuery] int PageSize = ChatMessageDefaultValues.PageSize) : ISortableApiRequest<ChatMessagesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
