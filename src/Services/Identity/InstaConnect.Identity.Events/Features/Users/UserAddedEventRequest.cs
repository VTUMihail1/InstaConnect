namespace InstaConnect.Identity.Events.Features.Users;
public record UserAddedEventRequest(
    UserIdEventPayload Id,
    NameEventPayload Name,
    EmailEventPayload Email,
    string FirstName,
    string LastName,
    ImageEventPayload? ProfileImage)
    : IEventRequest;
