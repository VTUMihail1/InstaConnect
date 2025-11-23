namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowAddedEventRequest(
        FollowIdEventPayload Id)
    : IEventRequest;
