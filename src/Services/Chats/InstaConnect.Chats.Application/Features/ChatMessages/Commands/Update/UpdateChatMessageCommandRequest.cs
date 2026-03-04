namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;

public record UpdateChatMessageCommandRequest(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string Content,
    string SenderId) : ICommandRequest<UpdateChatMessageCommandResponse>;
