using InstaConnect.Chats.Application.Features.Chats.Models;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public record GetAllChatsByParticipantApiResponse(
    ICollection<ChatApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
