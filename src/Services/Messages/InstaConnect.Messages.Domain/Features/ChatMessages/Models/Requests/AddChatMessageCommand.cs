namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;

public record AddChatMessageCommand(string ParticipantOneId, string ParticipantTwoId, string Content);
