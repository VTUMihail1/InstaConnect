namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record AddChatApiResponse(string ParticipantOneId, string ParticipantTwoId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
