namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

public record GetAllChatMessagesQuerySpecification(
    string Sql,
    GetAllChatMessagesQueryParameters Parameters);
