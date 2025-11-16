namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatDeletedEventRequest(ChatIdEventPayload Id)
    : IEventRequest;
