using InstaConnect.ChatMessages.Application.Features.ChatMessages.Models;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;

public record GetAllChatMessagesApiResponse(
    ICollection<ChatMessageApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
