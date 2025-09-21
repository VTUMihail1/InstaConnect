namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;

public record UpdateChatMessageCommand(string ParticipantOneId, string ParticipantTwoId, string MessageId, string Content);
