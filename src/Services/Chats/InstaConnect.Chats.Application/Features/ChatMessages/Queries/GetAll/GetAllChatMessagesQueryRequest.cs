namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesQueryRequest(
    ChatMessageQueryFilter Filter,
    ChatMessageQuerySorting Sorting,
    ChatMessageQueryPagination Pagination)
    : IQueryRequest<GetAllChatMessagesQueryResponse>;
