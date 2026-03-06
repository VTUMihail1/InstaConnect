namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageCollectionQueryResponse(
    ChatQueryResponse? Chat,
    UserQueryResponse? Sender,
    ICollection<ChatMessageQueryResponse> ChatMessages,
    int Page,
    int PageSize,
    long TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionQueryResponse;
