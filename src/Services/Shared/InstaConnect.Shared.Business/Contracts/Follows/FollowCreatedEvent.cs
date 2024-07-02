namespace InstaConnect.Shared.Business.Contracts.Follows;

public class FollowCreatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string FollowerId { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;
}
