using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Data.Read.Models.Entities;

public class Follow : BaseEntity
{
    public string FollowingId { get; set; }

    public User Following { get; set; }

    public string FollowerId { get; set; }

    public User Follower { get; set; }
}
