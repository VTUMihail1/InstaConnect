namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;

public record AddChatApiResponse(string ParticipantOneId, string ParticipantTwoId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
