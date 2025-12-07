namespace InstaConnect.Chats.Application.Features.Chats.Commands.Delete;

public record DeleteChatCommandRequest(string ParticipantOneId, string ParticipantTwoId) : ICommandRequest;
