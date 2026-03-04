namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetChatByIdQuery(
    ChatId Id,
    CurrentUserQuery CurrentUser) : ICurrentUserableQuery;
