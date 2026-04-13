using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesQueryRequest(
    string ParticipantTwoId,
    string CurrentUserId,
    CommonSortOrder SortOrder,
    ChatMessagesSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllChatMessagesQueryResponse>, ISortableQueryRequest<ChatMessagesSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
