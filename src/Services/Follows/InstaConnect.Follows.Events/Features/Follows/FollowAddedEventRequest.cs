namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowAddedEventRequest(
        FollowIdEventPayload Id,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
