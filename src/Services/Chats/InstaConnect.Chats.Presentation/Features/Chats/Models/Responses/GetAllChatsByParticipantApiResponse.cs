namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record GetAllChatsByParticipantApiResponse(
    ICollection<ChatApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
