namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

public record GetAllChatMessagesApiResponse(
    ICollection<ChatMessageApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
