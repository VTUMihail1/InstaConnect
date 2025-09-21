namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessagePaginationQuery(
    int Page,
    int PageSize);
