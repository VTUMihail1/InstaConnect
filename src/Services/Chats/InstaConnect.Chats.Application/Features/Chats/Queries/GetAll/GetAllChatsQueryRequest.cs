using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public record GetAllChatsQueryRequest(
    string ParticipantTwoName,
    string CurrentUserId,
    CommonSortOrder SortOrder,
    ChatsSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllChatsQueryResponse>, ISortableQueryRequest<ChatsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
