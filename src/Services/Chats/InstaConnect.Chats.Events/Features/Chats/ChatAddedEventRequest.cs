namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatAddedEventRequest(
        ChatIdEventPayload Id,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
