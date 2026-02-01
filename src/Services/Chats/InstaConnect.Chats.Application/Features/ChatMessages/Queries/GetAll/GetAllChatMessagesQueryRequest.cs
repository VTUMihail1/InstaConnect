using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesQueryRequest(
    string ParticipantOneId,
    string ParticipantTwoId,
    string UserId,
    CommonSortOrder SortOrder,
    ChatMessageSortProperty SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllChatMessagesQueryResponse>, ISortableQueryRequest<ChatMessageSortProperty>, IPaginatableQueryRequest;
