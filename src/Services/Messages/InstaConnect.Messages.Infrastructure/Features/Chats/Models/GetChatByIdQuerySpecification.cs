namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models;

public record GetChatByIdQuerySpecification(
    string Sql,
    GetChatByIdQueryParameters Parameters);
