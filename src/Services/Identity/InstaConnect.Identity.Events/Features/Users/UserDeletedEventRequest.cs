namespace InstaConnect.Identity.Events.Features.Users;
public record UserDeletedEventRequest(UserIdEventPayload Id) : IEventRequest;
