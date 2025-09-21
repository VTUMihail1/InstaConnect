namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

public record GetChatMessageByIdQuerySpecification(
    string Sql,
    GetChatMessageByIdQueryParameters Parameters);
