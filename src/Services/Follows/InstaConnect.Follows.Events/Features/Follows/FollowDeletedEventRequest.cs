namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowDeletedEventRequest(string FollowerId, string FollowingId)
    : IEventRequest;
