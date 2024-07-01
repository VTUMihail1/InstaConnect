namespace InstaConnect.Follows.Business.Read.Models;

public class FollowViewModel
{
    public string Id { get; set; } = string.Empty;

    public string FollowerId { get; set; } = string.Empty;

    public string FollowerName { get; set; } = string.Empty;

    public string FollowingId { get; set; } = string.Empty;

    public string FollowingName { get; set; } = string.Empty;
}
