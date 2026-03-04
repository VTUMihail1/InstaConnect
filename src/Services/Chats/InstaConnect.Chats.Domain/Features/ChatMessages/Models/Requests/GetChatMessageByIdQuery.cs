namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdQuery(
    ChatMessageId Id,
    CurrentUserQuery CurrentUser) : ICurrentUserableQuery;
