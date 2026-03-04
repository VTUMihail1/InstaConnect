namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatDeletedEventRequest(ChatEventRequest Chat) : IEventRequest;
