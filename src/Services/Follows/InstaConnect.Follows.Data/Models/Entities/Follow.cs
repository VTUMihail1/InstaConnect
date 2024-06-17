using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Data.Models.Entities;

public class Follow : BaseEntity
{
    public string FollowingId { get; set; }

    public string FollowingName { get; set; }

    public string FollowerId { get; set; }

    public string FollowerName { get; set; }
}
