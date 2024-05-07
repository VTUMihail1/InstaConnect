using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Data.Models.Entities;

public class Follow : BaseEntity
{
    public string FollowingId { get; set; }

    public string FollowerId { get; set; }
}
