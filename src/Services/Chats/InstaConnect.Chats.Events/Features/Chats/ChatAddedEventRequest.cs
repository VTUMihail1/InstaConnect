namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatAddedEventRequest(ChatEventRequest Chat) : IEventRequest;
