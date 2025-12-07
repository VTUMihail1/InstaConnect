using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesQueryRequest(
    string ParticipantOneId,
    string ParticipantTwoId,
    string UserId,
    CommonSortOrder SortOrder,
    ChatMessageSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllChatMessagesQueryResponse>;
