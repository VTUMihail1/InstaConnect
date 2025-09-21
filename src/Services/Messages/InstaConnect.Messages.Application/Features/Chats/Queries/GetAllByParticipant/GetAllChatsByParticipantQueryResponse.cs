using InstaConnect.Chats.Application.Features.Chats.Models;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public record GetAllChatsByParticipantQueryResponse(
    ICollection<ChatQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
