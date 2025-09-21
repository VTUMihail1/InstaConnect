using InstaConnect.Chats.Domain.Features.Chats.Models;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models;

public record GetAllChatsByParticipantTotalCountQuerySpecification(
    string Sql,
    GetAllChatsByParticipantTotalCountQueryParameters Parameters);
