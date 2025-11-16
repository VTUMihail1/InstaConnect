namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowDeletedEventRequest(FollowIdEventPayload Id)
    : IEventRequest;
