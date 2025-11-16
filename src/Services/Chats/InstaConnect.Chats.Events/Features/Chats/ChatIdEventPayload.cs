using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Events.Features.Chats;

public record ChatIdEventPayload(UserIdEventPayload ParticipantOne, UserIdEventPayload ParticipantTwo);
