namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageQueryFilter(
    string ParticipantOneId,
    string ParticipantTwoId);
