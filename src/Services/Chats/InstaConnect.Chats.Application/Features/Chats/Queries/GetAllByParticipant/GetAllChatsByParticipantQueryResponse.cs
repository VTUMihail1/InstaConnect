namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;

public record GetAllChatsByParticipantQueryResponse(
    ICollection<ChatQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
