namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Delete;

public record DeleteChatMessageCommandRequest(
    string ParticipantOneId, string ParticipantTwoId, string MessageId) : ICommandRequest;
