namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatAddedEventRequest(
        string ParticipantOne,
        string ParticipantTwo,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
