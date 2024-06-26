namespace InstaConnect.Shared.Business.Contracts.Follows;

public class FollowCreatedEvent
{
    public string Id { get; set; }

    public string FollowerId { get; set; }

    public string FollowingId { get; set; }
}
