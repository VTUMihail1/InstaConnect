namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;

public record UpdateChatMessageCommandRequest(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string SenderId,
    string Content) : ICommandRequest<UpdateChatMessageCommandResponse>;
