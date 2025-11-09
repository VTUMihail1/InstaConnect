namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record DeleteChatMessageCommand(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId);
