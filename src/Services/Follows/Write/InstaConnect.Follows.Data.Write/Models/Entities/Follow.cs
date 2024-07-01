using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Data.Write.Models.Entities;

public class Follow : BaseEntity
{
    public string FollowerId { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;
}
