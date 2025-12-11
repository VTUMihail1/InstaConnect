namespace InstaConnect.Identity.Events.Features.Users;
public sealed record UserDeletedEventRequest(string Id) : IEventRequest;
