using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesQueryRequest(
    ChatMessageQueryFilter Filter,
    ChatMessageQuerySorting Sorting,
    ChatMessageQueryPagination Pagination)
    : IQueryRequest<GetAllChatMessagesQueryResponse>;
