namespace InstaConnect.Identity.Events.Features.Users;
public record UserDeletedEventRequest(string Id) : IEventRequest;
