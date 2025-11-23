namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatAddedEventRequest(ChatIdEventPayload Id)
    : IEventRequest;
