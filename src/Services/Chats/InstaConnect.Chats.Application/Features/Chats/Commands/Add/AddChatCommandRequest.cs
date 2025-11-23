namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;

public record AddChatCommandRequest(UserIdPayload ParticipantOneId, UserIdPayload ParticipantTwoId) : ICommandRequest<AddChatCommandResponse>;
