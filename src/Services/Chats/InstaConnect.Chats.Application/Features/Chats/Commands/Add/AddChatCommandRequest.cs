namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;

public record AddChatCommandRequest(string ParticipantOneId, string ParticipantTwoId) : ICommandRequest<AddChatCommandResponse>;
