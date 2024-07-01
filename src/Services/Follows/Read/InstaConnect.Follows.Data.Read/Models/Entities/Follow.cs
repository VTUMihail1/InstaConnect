using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Data.Read.Models.Entities;

public class Follow : BaseEntity
{
    public string FollowingId { get; set; } = string.Empty;

    public User Following { get; set; } = new();

    public string FollowerId { get; set; } = string.Empty;

    public User Follower { get; set; } = new();
}
