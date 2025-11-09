namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesQueryResponse(
    ICollection<ChatMessageQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
