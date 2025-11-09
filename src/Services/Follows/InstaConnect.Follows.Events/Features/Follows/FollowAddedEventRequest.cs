namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowAddedEventRequest(
        string FollowerId,
        string FollowingId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
