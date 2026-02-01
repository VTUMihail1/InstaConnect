namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatPaginationQuery(
    int Page,
    int PageSize);
