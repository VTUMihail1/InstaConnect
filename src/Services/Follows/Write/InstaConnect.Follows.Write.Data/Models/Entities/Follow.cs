using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Write.Data.Models.Entities;

public class Follow : BaseEntity
{
    public string FollowerId { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;
}
