namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;

public record AddChatMessageCommandRequest(
    string ParticipantOneId,
    string ParticipantTwoId,
    string Content) : ICommandRequest<AddChatMessageCommandResponse>;
