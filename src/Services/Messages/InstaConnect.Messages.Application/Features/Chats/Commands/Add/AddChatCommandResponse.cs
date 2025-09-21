namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;

public record AddChatCommandResponse(string ParticipantOneId, string ParticipantTwoId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
