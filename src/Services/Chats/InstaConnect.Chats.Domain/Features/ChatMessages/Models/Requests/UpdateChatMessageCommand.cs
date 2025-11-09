namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record UpdateChatMessageCommand(string ParticipantOneId, string ParticipantTwoId, string MessageId, string Content);
