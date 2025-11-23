namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesQueryRequest(
    ChatMessageFilterQueryRequest Filter,
    ChatMessageSortingQueryRequest Sorting,
    ChatMessagePaginationQueryRequest Pagination)
    : IQueryRequest<GetAllChatMessagesQueryResponse>;
