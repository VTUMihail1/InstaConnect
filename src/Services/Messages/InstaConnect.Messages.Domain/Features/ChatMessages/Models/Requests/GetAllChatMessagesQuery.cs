namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesQuery(
    ChatMessageFilterQuery Filter,
    ChatMessageSortingQuery Sorting,
    ChatMessagePaginationQuery Pagination);
