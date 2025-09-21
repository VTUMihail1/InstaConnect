namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models;

public record GetChatByIdQueryParameters(
    string ParticipantOneId,
    string ParticipantTwoId);
