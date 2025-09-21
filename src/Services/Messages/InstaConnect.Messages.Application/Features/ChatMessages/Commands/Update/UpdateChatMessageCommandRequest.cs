namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Update;

public record UpdateChatMessageCommandRequest(string ParticipantOneId, string ParticipantTwoId, string MessageId, string Content) : ICommandRequest<UpdateChatMessageCommandResponse>;
