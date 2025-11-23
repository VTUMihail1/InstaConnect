namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatPaginationQueryRequest(
    int Page,
    int PageSize);
