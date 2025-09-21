namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record DeleteChatCommand(
    string ParticipantOneId,
    string ParticipantTwoId);
