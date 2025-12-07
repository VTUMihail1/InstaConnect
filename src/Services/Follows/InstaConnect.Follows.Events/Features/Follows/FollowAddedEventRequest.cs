namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowAddedEventRequest(
        string FollowerId,
        string FollowingId,
        DateTimeOffset CreatedAtUtc)
    : IEventRequest;
