namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models;

public record GetAllChatsByParticipantQuerySpecification(
    string Sql,
    GetAllChatsByParticipantQueryParameters Parameters);
