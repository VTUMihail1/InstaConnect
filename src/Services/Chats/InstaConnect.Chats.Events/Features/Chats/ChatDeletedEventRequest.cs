namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatDeletedEventRequest(string ParticipantOne, string ParticipantTwo)
    : IEventRequest;
